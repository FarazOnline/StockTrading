using Microsoft.EntityFrameworkCore;
using StockTrader.Domain.Models;

namespace StockTrader.EntityFramework
{
    public class StockTraderDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AssetTransaction> AssetTransactions { get; set; }
        public StockTraderDbContext(DbContextOptions options) : base(options) {}
        protected override void OnModelCreating(ModelBuilder MB)
        {
            MB.Entity<AssetTransaction>().OwnsOne(x => x.WhichStock);
            base.OnModelCreating(MB);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder DBCOB)
        //{
        //    DBCOB.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=STDB2;Trusted_Connection=True;");
        //    base.OnConfiguring(DBCOB);
        //}
    }
}
