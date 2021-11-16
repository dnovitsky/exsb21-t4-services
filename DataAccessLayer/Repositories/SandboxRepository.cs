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
        const string DataType = "d";

        public AppDbContext db;
        public SandboxRepository(AppDbContext context)
            : base(context)
        {
            db = context;
            // db.Add()
        }

        public async Task<SandboxEntityModel> FindByIdAsync(Guid id)
        {
            return await db.Sandboxes.FindAsync(id);
        }

        public async Task<IEnumerable<SandboxEntityModel>> GetAllAsync()
        {
            return await Task.Run(() => db.Sandboxes.AsEnumerable());
        }

        public async Task<PagedList<SandboxEntityModel>> GetPagedAsync(InputParametrsEntityModel parametrs, FilterParametrsEntityModel filterParametrs)
        {
            int pageNumber = parametrs.PageNumber;
            int pageSize = parametrs.PageSize;
            SortType SortingType = parametrs.SortingType;

            int numberNotes = db.Sandboxes.Count();
            int totalPages = (int)Math.Ceiling((double)numberNotes / (double)pageSize);

            PagedList<SandboxEntityModel> pagedList = new PagedList<SandboxEntityModel>();

            pagedList.PageList = filterParametrs.SearchingDateField switch
            {
                CreateDate => await Task.Run(() => db.Sandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString) &&
                s.CreateDate.ToString().Contains(filterParametrs.SearchingDateString))),

                StartDate => await Task.Run(() => db.Sandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString) &&
                s.StartDate.ToString().Contains(filterParametrs.SearchingDateString))),

                StartRegistration => await Task.Run(() => db.Sandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString) &&
                s.StartRegistration.ToString().Contains(filterParametrs.SearchingDateString))),

                _ => await Task.Run(() => db.Sandboxes
                .Where(s => s.Name.Contains(filterParametrs.FirstSearchingTextString) &&
                s.Description.Contains(filterParametrs.SecondSearchingTextString))),
            };

            pagedList.PageList = parametrs.SortField.ToLower() switch
            {
                Name => (SortingType == 0 ?
                pagedList.PageList.OrderBy(s => s.Name).ToList() :
                pagedList.PageList.OrderByDescending(s => s.Name).ToList()),

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

                _ => pagedList.PageList.OrderBy(s => s.CreateDate).ToList(),
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

        public void Update(SandboxEntityModel item)
        {
            db.Sandboxes.Update(item);
        }
        public void Delete(Guid id)
        {

        }
    }
}
