using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public static class UserTeamConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTeamEntityModel>()
                .HasOne(d => d.UserSandBox) //typeof(UserEntityModel), "User"
                .WithMany(p => p.UserTeams)
                .HasForeignKey(d => d.UserSandBoxId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //.HasConstraintName("SupportChatMembers_SupportChatId_fkey");
        }
    }
}
