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
        public async Task<PagedList<SandboxEntityModel>> GetPagedAsync(InputParametrsEntityModel parametrs)
        {
            int pageNumber = parametrs.PageNumber;
            int pageSize = parametrs.PageSize;
            string searchString = parametrs.SearchingString;


            int numberNotes = db.Sandboxes.Count();
            int totalPages = (int)Math.Ceiling((double)numberNotes / (double)pageSize);

            PagedList<SandboxEntityModel> pagedList = new PagedList<SandboxEntityModel>();

            if (!string.IsNullOrEmpty(searchString))
            {
                pagedList.PageList = db.Sandboxes.Where(s => s.Description.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            switch (parametrs.SortField.ToLower())
            {
                case "name":
                    pagedList.PageList = pagedList.PageList.OrderBy(s => s.Name).ToList();
                    break;
                case "maxcandidates":
                    pagedList.PageList = pagedList.PageList.OrderBy(s => s.MaxCandidates).ToList();
                    break;
                case "createdate":
                    pagedList.PageList = pagedList.PageList.OrderBy(s => s.CreateDate).ToList();
                    break;
                case "startdate":
                    pagedList.PageList = pagedList.PageList.OrderBy(s => s.StartDate).ToList();
                    break;
                case "description":
                    pagedList.PageList = pagedList.PageList.OrderBy(s => s.Description).ToList();
                    break;
                case "enddate":
                    pagedList.PageList = pagedList.PageList.OrderBy(s => s.EndDate).ToList();
                    break;
                case "startregistration":
                    pagedList.PageList = pagedList.PageList.OrderBy(s => s.StartRegistration).ToList();
                    break;
                case "endregistration":
                    pagedList.PageList = pagedList.PageList
                        .OrderBy(s => s.EndRegistration)
                        .Skip(pageNumber - 1)
                        .Take(pageSize)
                        .ToList();
                    break;
                default:
                    break;
            }

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
            // db.SaveChanges();
        }
        public void Delete(Guid id)
        {

        }
    }
}
