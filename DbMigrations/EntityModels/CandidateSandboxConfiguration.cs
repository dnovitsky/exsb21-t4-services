using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public static class CandidateSandboxConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateSandboxEntityModel>()
                .HasOne(d => d.Team) //typeof(UserEntityModel), "User"
                .WithMany() //p => p.CandidateSandboxes
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //.HasConstraintName("SupportChatMembers_SupportChatId_fkey");
        }
    }
}
