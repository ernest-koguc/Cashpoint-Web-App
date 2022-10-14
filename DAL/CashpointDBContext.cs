using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class CashpointDBContext : DbContext
    {
        private readonly string _connectionString = "Server=DESKTOP-XXXXXXXX;Database=Cashpoint_db;Trusted_Connection=True;";

        public DbSet<UserAccount> Accounts { get; set; } = null!;

        public DbSet<CashpointBalance> Balances { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .Property(r => r.Balance).IsRequired();
        }
    }
}
