﻿using DbMigrations.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DbMigrations.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TestModel> TestTable { get; set; }

    }
}
