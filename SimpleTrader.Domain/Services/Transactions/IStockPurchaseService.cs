using StockTrader.Domain.Models;
using System.Threading.Tasks;

namespace StockTrader.Domain.Services.Transactions
{
    public interface IStockPurchaseService
    {
        Task<Account> StockPurchase(Account Buyer, string Stock, int Qty);
    }
}