using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Service;
using DataAccessLayer.Models;

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

        public async Task<PagedList<CandidateEntityModel>> GetPagedAsync(InputParametrsDalModel parametrs, CandidateFilterParametrsDalModel candidateFilterParametrs)
        {
            int pageNumber = parametrs.PageNumber;
            int pageSize = parametrs.PageSize;
            SortType SortingType = parametrs.SortingType;

            int numberNotes = db.Candidates.Count();
            int totalPages = (int)Math.Ceiling((double)numberNotes / (double)pageSize);

            PagedList<CandidateEntityModel> pagedList = new PagedList<CandidateEntityModel>();

            var locations = candidateFilterParametrs.Locations;
            var sandboxes = candidateFilterParametrs.Sandboxes;
            var statuses = candidateFilterParametrs.Statuses;
            var mentors = candidateFilterParametrs.Mentors;

            pagedList.PageList = await Task.Run(() => db.Candidates.Where(candidate => 
                (locations == null || !locations.Any() || candidate.CandidateSandboxes.Where(s => locations.Contains(s.Candidate.Location.Id)).Any())
                && (sandboxes == null || !sandboxes.Any() || candidate.CandidateSandboxes.Where(s => sandboxes.Contains(s.Sandbox.Id)).Any()) 
                && (statuses == null || !statuses.Any() || candidate.CandidateSandboxes.Where(s => s.CandidateProcesses.Where(x => statuses.Contains(x.Status.Id)).Any()).Any())
                && (mentors == null || !mentors.Any() || candidate.CandidateSandboxes.Where(
                    s => s.Sandbox.Teams.Where(
                        x => x.UserTeams.Where(u => mentors.Contains(u.UserSandBox.UserId)).Any()
                    ).Any()
                  ).Any()
                )
            ));

            if (parametrs.SortField != "")
            {
                pagedList.PageList = parametrs.SortField.ToLower() switch
                {
                    "name" => (SortingType == 0 ?
                    pagedList.PageList.OrderBy(s => s.Name).AsEnumerable() :
                    pagedList.PageList.OrderByDescending(s => s.Name).AsEnumerable()),

                    "surname" => (SortingType == 0 ?
                    pagedList.PageList.OrderBy(s => s.Surname).AsEnumerable() :
                    pagedList.PageList.OrderByDescending(s => s.Surname).AsEnumerable()),

                    "email" => (SortingType == 0 ?
                    pagedList.PageList.OrderBy(s => s.Email).AsEnumerable() :
                    pagedList.PageList.OrderByDescending(s => s.Email).AsEnumerable()),

                    "status" => (SortingType == 0 ?
                    pagedList.PageList.OrderBy(s => getStatusNameFromCandidateProcesses(s)).AsEnumerable() :
                    pagedList.PageList.OrderByDescending(s => getStatusNameFromCandidateProcesses(s)).AsEnumerable()),

                    "sandbox" => (SortingType == 0 ?
                    pagedList.PageList.OrderBy(s => getSandboxNameFromCandidateSandbox(s)).AsEnumerable() :
                    pagedList.PageList.OrderByDescending(s => getSandboxNameFromCandidateSandbox(s)).AsEnumerable()),

                    _ => pagedList.PageList.OrderBy(s => s.Name).AsEnumerable(),
                };
            }

            pagedList.PageList = pagedList.PageList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            pagedList.TotalPages = totalPages;
            pagedList.CurrentPage = pageNumber;

            return pagedList;
        }

        private CandidateSandboxEntityModel getActualCandidateSandboxes(CandidateEntityModel candidateEM)
        {
            return candidateEM.CandidateSandboxes.Where(s => DateTime.Now < s.Sandbox.EndDate).FirstOrDefault();
        }

        private string getSandboxNameFromCandidateSandbox(CandidateEntityModel candidateEM)
        {
            return getActualCandidateSandboxes(candidateEM).Sandbox.Name;
        }

        private string getStatusNameFromCandidateProcesses(CandidateEntityModel candidateEM)
        {
            return getActualCandidateSandboxes(candidateEM).CandidateProcesses.LastOrDefault().Status.Name;
        }
    }
}
