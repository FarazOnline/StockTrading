using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StockTrader.EntityFramework
{
    public class StockTraderDbContextFactory : IDesignTimeDbContextFactory<StockTraderDbContext>
    {
        public StockTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<StockTraderDbContext>();
            options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=STDBMS;Trusted_Connection=True;");
            return new StockTraderDbContext(options.Options);
        }
    }
}
