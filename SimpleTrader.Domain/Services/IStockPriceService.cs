using System.Threading.Tasks;

namespace StockTrader.Domain.Services
{
    public interface IStockPriceService
    {
        Task<double> GetPrice(string symbol);
    }
}
