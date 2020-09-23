using StockTrader.API.Results;
using StockTrader.Domain.Exceptions;
using StockTrader.Domain.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace StockTrader.API.Services
{
    //https://financialmodelingprep.com/api/v3/stock/real-time-price/AAPL?apikey=3b8cf2611a3a74d31a8178b509d24edf
    public class StockPriceService : IStockPriceService
    {
        public string APIKey = "3b8cf2611a3a74d31a8178b509d24edf";
        public async Task<double> GetPrice(string symbol)
        {
            using (ApiHttpClient client = new ApiHttpClient())
            {
                string uri = "stock/real-time-price/" + symbol + "?apikey=" + APIKey;
                StockPriceResult SPR = await client.GetAsync<StockPriceResult>(uri);
                if (SPR.Price == 0)
                {
                    throw new InvalidSymbolX(symbol);
                }
                Debug.Write("\r\n====================================");
                Debug.Write("\r\nURI: " + uri);
                Debug.Write("\r\nIndexSymbol: " + SPR.Symbol);
                Debug.Write("\r\nIndexPrice: " + SPR.Price);
                Debug.Write("\r\n====================================");
                return SPR.Price;
            }
        }
    }
}
