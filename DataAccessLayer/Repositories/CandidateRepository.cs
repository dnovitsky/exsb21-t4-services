using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Service;

namespace DataAccessLayer.Repositories
{
    public class CandidateRepository : Repository<CandidateEntityModel>, ICandidateRepository
    {
        const string Status = "status";
        const string Location = "location";
        const string Mentor = "mentor";
        const string Sandbox = "sandbox";
        const string Name = "name";
        private AppDbContext db;

        public CandidateRepository(AppDbContext context)
            : base(context)
        {
            db = context;
        }

        public async Task<PagedList<CandidateEntityModel>> GetPagedAsync(InputParametrsEntityModel parametrs, FilterParametrsEntityModel filterParametrs)
        {
            int pageNumber = parametrs.PageNumber;
            int pageSize = parametrs.PageSize;
            SortType SortingType = parametrs.SortingType;

            int numberNotes = db.Candidates.Count();
            int totalPages = (int)Math.Ceiling((double)numberNotes / (double)pageSize);

            PagedList<CandidateEntityModel> pagedList = new PagedList<CandidateEntityModel>();

            pagedList.PageList = filterParametrs.SearchingDateField switch
            {
                Status => await Task.Run(() => db.Candidates 
                .Where( s => s.CandidateSandboxes.Where(s => s.CandidateProcesses.Where(s => s.Status.Name.Contains(filterParametrs.FirstSearchingTextString)).Any()).Any())),

                Location => await Task.Run(() => db.Candidates
                .Where(s => s.CandidateSandboxes.Where(s => s.Candidate.Location.Name.Contains(filterParametrs.FirstSearchingTextString)).Any())),

                /*
                Mentor => await Task.Run(() => db.CandidateSandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString) &&
                s.StartRegistration.ToString().Contains(filterParametrs.SearchingDateString))),
                */

                Sandbox => await Task.Run(() => db.Candidates
                .Where(s => s.CandidateSandboxes.Where(s => s.Sandbox.Name.Contains(filterParametrs.FirstSearchingTextString)).Any())),

                _ => await Task.Run(() => db.Candidates
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString))),
            };

            /*
            if (filterParametrs.SearchingStatus != SearchStatus.None)
            {
                pagedList.PageList = pagedList.PageList.Where(s => s.Status == (StatusName)filterParametrs.SearchingStatus);
            }
            */

            pagedList.PageList = parametrs.SortField.ToLower() switch
            {
                Name => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.Name).ToList() :
                pagedList.PageList.OrderByDescending(s => s.Name).ToList()),
                /*
                MaxCandidates => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.MaxCandidates).ToList() :
                pagedList.PageList.OrderByDescending(s => s.MaxCandidates).ToList()),

                CreateDate => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.CreateDate).ToList() :
                pagedList.PageList.OrderByDescending(s => s.CreateDate).ToList()),

                StartDate => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.StartDate).ToList() :
                pagedList.PageList.OrderByDescending(s => s.StartDate).ToList()),

                EndDate => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.EndDate).ToList() :
                pagedList.PageList.OrderByDescending(s => s.EndDate).ToList()),

                StartRegistration => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.StartRegistration).ToList() :
                pagedList.PageList.OrderByDescending(s => s.StartRegistration).ToList()),

                Endregistration => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.EndRegistration).ToList() :
                pagedList.PageList.OrderByDescending(s => s.EndRegistration).ToList()),

                Status => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.Status).ToList() :
                pagedList.PageList.OrderByDescending(s => s.Status).ToList()),
                */
                _ => pagedList.PageList.OrderBy(s => s.Name).ToList(),
            };

            pagedList.PageList = pagedList.PageList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            pagedList.TotalPages = totalPages;
            pagedList.CurrentPage = pageNumber;

            return pagedList;
        }
    }
}
