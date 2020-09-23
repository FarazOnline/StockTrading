using Microsoft.EntityFrameworkCore;
using StockTrader.Domain.Models;
using StockTrader.Domain.Services;
using StockTrader.EntityFramework.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrader.EntityFramework.Services
{
    public class GenericDataService<F> : IDataService<F> where F : CurrentObject
    {
        private readonly StockTraderDbContextFactory _STDBCF;
        private readonly CRUDService<F> _CRUDService;

        public GenericDataService(StockTraderDbContextFactory STDBCF)
        {
            _STDBCF = STDBCF;
            _CRUDService = new CRUDService<F>(STDBCF);
        }

        public async Task<F> Create(F entity)
        {
            return await _CRUDService.Create(entity);
        }

        public async Task<IEnumerable<F>> GetAll()
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                IEnumerable<F> GetEntities = await CNTXT.Set<F>().ToListAsync();
                return GetEntities;
            }
        }

        public async Task<F> GetOne(int id)
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                F GetEntity = await CNTXT.Set<F>().FirstOrDefaultAsync((f) => f.Id == id);
                return GetEntity;
            }
        }

        public async Task<F> Update(int id, F UpdatedEntity)
        {
            return await _CRUDService.Update(id, UpdatedEntity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _CRUDService.Delete(id);
        }
    }
}
