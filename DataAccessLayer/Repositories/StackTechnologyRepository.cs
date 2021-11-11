﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMigrations.EntityModels;
using DbMigrations.Data;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositories
{
    public class StackTechnologyRepository : Repository<StackTechnologyEntityModel>, IStackTechnologyRepository
    {
        private readonly AppDbContext db;
        public StackTechnologyRepository(AppDbContext context)
            : base(context)
        {
           db = context;
        }

        public async Task<IEnumerable<StackTechnologyEntityModel>> GetBySandboxId(Guid id)
        {
            IEnumerable<SandboxStackTechnologyEntityModel> sandboxStackTech = db.SandboxStackTechnologies.Where(s => s.SandboxId == id);
            IList<StackTechnologyEntityModel> stackTechnology = new List<StackTechnologyEntityModel> { };

            foreach (var a in sandboxStackTech)
            {
                stackTechnology.Add(db.StackTechnologies.Find(a.StackTechnologyId));
            }
            return stackTechnology;

            // return db.StackTechnologies.ToList();

        }
    }
}
