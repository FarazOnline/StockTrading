using StockTrader.Domain.Models;
using System.Threading.Tasks;

namespace StockTrader.Domain.Services
{
    public interface ILoginService : IDataService<Account>
    {
        Task<Account> GetByUsername(string username);
        Task<Account> GetByEmail(string email);
    }
}
