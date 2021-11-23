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
        private AppDbContext db;

        public CandidateRepository(AppDbContext context)
            : base(context)
        {
            db = context;
        }

        public async Task<PagedList<CandidateEntityModel>> GetPagedAsync(InputParametrsEntityModel parametrs, CandidateFilterParametrsEntityModel candidateFilterParametrs)
        {
            int pageNumber = parametrs.PageNumber;
            int pageSize = parametrs.PageSize;
            SortType SortingType = parametrs.SortingType;

            int numberNotes = db.Candidates.Count();
            int totalPages = (int)Math.Ceiling((double)numberNotes / (double)pageSize);

            PagedList<CandidateEntityModel> pagedList = new PagedList<CandidateEntityModel>();

            var LocationId = candidateFilterParametrs.LocationId;
            var SandboxId = candidateFilterParametrs.SandboxId;
            var SearchStatus = candidateFilterParametrs.SearchingStatus;
            var MentorId = candidateFilterParametrs.MentorId;

            pagedList.PageList = await Task.Run(() => db.Candidates.Where(candidate => 
                (LocationId == null || candidate.CandidateSandboxes.Where(s => s.Candidate.Location.Id == LocationId).Any())
                && (SandboxId == null || candidate.CandidateSandboxes.Where(s => s.Sandbox.Id == SandboxId).Any()) 
                && (SearchStatus == SearchStatus.None || candidate.CandidateSandboxes.Where(s => s.CandidateProcesses.Where(x => x.Status.Name.Contains(SearchStatus.ToString())).Any()).Any())
                && (MentorId == null || candidate.CandidateSandboxes.Where(
                    s => s.Sandbox.Teams.Where(
                        x => x.UserTeams.Where(u => u.UserSandBox.UserId == MentorId).Any()
                    ).Any()
                  ).Any()
                )
            ));

            if(parametrs.SortField != "")
            {
                pagedList.PageList = SortingType == 0 ?  pagedList.PageList.OrderBy(s => s.Name).ToList() : pagedList.PageList.OrderByDescending(s => s.Name).ToList();
            }

            pagedList.PageList = pagedList.PageList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            pagedList.TotalPages = totalPages;
            pagedList.CurrentPage = pageNumber;

            return pagedList;
        }
    }
}
