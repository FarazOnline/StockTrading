using Microsoft.EntityFrameworkCore;
using StockTrader.Domain.Models;
using StockTrader.Domain.Services;
using StockTrader.EntityFramework.Services.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockTrader.EntityFramework.Services
{
    public class AccountDataService : ILoginService
    {
        private readonly StockTraderDbContextFactory _STDBCF;
        private readonly CRUDService<Account> _CRUDService;

        public AccountDataService(StockTraderDbContextFactory STDBCF)
        {
            _STDBCF = STDBCF;
            _CRUDService = new CRUDService<Account>(STDBCF);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _CRUDService.Create(entity);
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                IEnumerable<Account> GetEntities = await CNTXT.Accounts
                    .Include(f => f.WhichUser)
                    .Include(f => f.AssetTransactions)
                    .ToListAsync();
                return GetEntities;
            }
        }

        public async Task<Account> GetOne(int id)
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                Account GetEntity = await CNTXT.Accounts
                    .Include(f => f.WhichUser)
                    .Include(f => f.AssetTransactions)
                    .FirstOrDefaultAsync((f) => f.AccountId == id);
                return GetEntity;
            }
        }

        public async Task<Account> Update(int id, Account UpdatedEntity)
        {
            return await _CRUDService.Update(id, UpdatedEntity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _CRUDService.Delete(id);
        }

        public async Task<Account> GetByUsername(string username)
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                return await CNTXT.Accounts
                    .Include(f => f.WhichUser)
                    .Include(f => f.AssetTransactions)
                    .FirstOrDefaultAsync(f => f.WhichUser.Username == username);
            }
        }

        public async Task<Account> GetByEmail(string email)
        {
            using (StockTraderDbContext CNTXT = _STDBCF.CreateDbContext())
            {
                return await CNTXT.Accounts
                    .Include(f => f.WhichUser)
                    .Include(f => f.AssetTransactions)
                    .FirstOrDefaultAsync(f => f.WhichUser.Email == email);
            }
        }
    }
}
