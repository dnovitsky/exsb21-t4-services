﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public static class CandidateProccessTestTasksConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateProccessTestTasksEntityModel>()
                .HasOne(d => d.СandidateProcess)
                .WithMany(p => p.СandidateProccessTestTasks)
                .HasForeignKey(d => d.CandidateProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<CandidateProccessTestTasksEntityModel>()
                .HasOne(d => d.TestFile)
                .WithMany(p => p.СandidateProccessTestTasks)
                .HasForeignKey(d => d.TestFileId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
