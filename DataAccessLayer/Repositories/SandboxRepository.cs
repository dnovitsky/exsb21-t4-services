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
    public class SandboxRepository : Repository<SandboxEntityModel>, ISandboxRepository
    {
        const string Name = "name";
        const string MaxCandidates = "maxcandidates";
        const string CreateDate = "createdate";
        const string StartDate = "startdate";
        const string Description = "description";
        const string EndDate = "enddate";
        const string StartRegistration = "startregistration";
        const string Endregistration = "endregistration";
        const string Status = "status";
        const string DataType = "d";

        public AppDbContext db;
        public SandboxRepository(AppDbContext context)
            : base(context)
        {
            db = context;
        }

        public async Task<SandboxEntityModel> FindByIdAsync(Guid id)
        {
            return await db.Sandboxes.FindAsync(id);
        }

        public async Task<IEnumerable<SandboxEntityModel>> GetAllAsync()
        {
            return await Task.Run(() => db.Sandboxes.AsEnumerable());
        }

        public async Task<PagedList<SandboxEntityModel>> GetPagedAsync(InputParametrsDalModel parametrs, FilterParametrsDalModel filterParametrs)
        {
            int pageNumber = parametrs.PageNumber;
            int pageSize = parametrs.PageSize;
            SortType SortingType = parametrs.SortingType;

            int numberNotes = db.Sandboxes.Count();
            int totalPages = (int)Math.Ceiling((double)numberNotes / (double)pageSize);

            PagedList<SandboxEntityModel> pagedList = new PagedList<SandboxEntityModel>();

            pagedList.PageList = filterParametrs.SearchingDateField.ToLower() switch
            {
                CreateDate => await Task.Run(() => db.Sandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString) &&
                s.CreateDate.ToString().Contains(filterParametrs.SearchingDateString)).AsEnumerable()),

                StartDate => await Task.Run(() => db.Sandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString) &&
                s.StartDate.ToString().Contains(filterParametrs.SearchingDateString)).AsEnumerable()),

                StartRegistration => await Task.Run(() => db.Sandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString) &&
                s.StartRegistration.ToString().Contains(filterParametrs.SearchingDateString)).AsEnumerable()),

                _ => await Task.Run(() => db.Sandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString)).AsEnumerable()),
            };

            if ( filterParametrs.SearchingStatus != SearchStatus.None)
            { 
                pagedList.PageList = pagedList.PageList.Where(s => s.Status == (StatusName)filterParametrs.SearchingStatus).ToList();
            }

            pagedList.PageList = pagedList.PageList
                .Where(s => s.Name.ToLower().Contains(filterParametrs.SearchingStringAll.ToLower()) ||
                s.Description.ToLower().Contains(filterParametrs.SearchingStringAll.ToLower()) ||
                s.StartDate.ToString().ToLower().Contains(filterParametrs.SearchingStringAll.ToLower()) ||
                s.Status.ToString().ToLower().Contains(filterParametrs.SearchingStringAll.ToLower())).AsEnumerable();


            pagedList.PageList = parametrs.SortField.ToLower() switch
            {
                Name => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.Name).AsEnumerable() :
                pagedList.PageList.OrderByDescending(s => s.Name).AsEnumerable()),

                MaxCandidates => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.MaxCandidates).AsEnumerable() :
                pagedList.PageList.OrderByDescending(s => s.MaxCandidates).AsEnumerable()),

                CreateDate => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.CreateDate).AsEnumerable() :
                pagedList.PageList.OrderByDescending(s => s.CreateDate).AsEnumerable()),

                StartDate => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.StartDate).AsEnumerable() :
                pagedList.PageList.OrderByDescending(s => s.StartDate).AsEnumerable()),

                EndDate => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.EndDate).AsEnumerable() :
                pagedList.PageList.OrderByDescending(s => s.EndDate).AsEnumerable()),

                StartRegistration => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.StartRegistration).AsEnumerable() :
                pagedList.PageList.OrderByDescending(s => s.StartRegistration).AsEnumerable()),

                Endregistration => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.EndRegistration).AsEnumerable() :
                pagedList.PageList.OrderByDescending(s => s.EndRegistration).AsEnumerable()),

                Status => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.Status).AsEnumerable() :
                pagedList.PageList.OrderByDescending(s => s.Status).AsEnumerable()),

                _ => pagedList.PageList.OrderBy(s => s.CreateDate).AsEnumerable(),
            };

            pagedList.PageList = pagedList.PageList.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            pagedList.TotalPages = totalPages;
            pagedList.CurrentPage = pageNumber;

            return pagedList;
        }

        public async Task CreateAsync(SandboxEntityModel item)
        {
            await db.Sandboxes.AddAsync(item);
        }

        public async Task Update(SandboxEntityModel item)
        {
           // await Task.(()db.Sandboxes.Update(item);
        }
        public void Delete(Guid id)
        {

        }
    }
}
