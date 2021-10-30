using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public static class UserSandboxConfiguration
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSandBoxEntityModel>()
                .HasOne(d => d.User)
                .WithMany(p => p.UserSanboxes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //.HasConstraintName("SupportChatMembers_SupportChatId_fkey");
        }
    }
}
