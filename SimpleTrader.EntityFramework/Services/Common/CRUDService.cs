using Microsoft.EntityFrameworkCore;
using StockTrader.Domain.Models;
using System.Threading.Tasks;

namespace StockTrader.EntityFramework.Services.Common
{
    public class CRUDService<F> where F : CurrentObject
    {
        private readonly StockTraderDbContextFactory _STDBCF;

        public CRUDService(StockTraderDbContextFactory STDBCF)
        {
            _STDBCF = STDBCF;
        }

        public async Task<F> Create(F entity)
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                var CreatedEntity = await CNTXT.Set<F>().AddAsync(entity);
                await CNTXT.SaveChangesAsync();
                return CreatedEntity.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                F DeletedEntity = await CNTXT.Set<F>().FirstOrDefaultAsync((f) => f.Id == id);
                CNTXT.Set<F>().Remove(DeletedEntity);
                await CNTXT.SaveChangesAsync();
                return true;
            }
        }

        public async Task<F> Update(int id, F UpdatedEntity)
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                UpdatedEntity.Id = id;
                CNTXT.Set<F>().Update(UpdatedEntity);
                await CNTXT.SaveChangesAsync();
                return UpdatedEntity;
            }

        }
    }
}
