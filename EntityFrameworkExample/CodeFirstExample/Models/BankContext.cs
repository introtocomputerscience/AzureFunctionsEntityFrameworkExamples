using System.Data.Entity;

namespace CodeFirstExample.Models
{
    public class BankContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Account>(a => a.Accounts)
                .WithMany(u => u.Users)
                .Map(ua =>
                {
                    ua.MapLeftKey("UserId");
                    ua.MapRightKey("AccountId");
                    ua.ToTable("AccountMapping", "Bank");
                });
        }
    }
}
