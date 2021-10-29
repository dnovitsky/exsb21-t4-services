using Microsoft.EntityFrameworkCore;


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
