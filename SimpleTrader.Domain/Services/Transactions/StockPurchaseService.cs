using StockTrader.Domain.Exceptions;
using StockTrader.Domain.Models;
using System;
using System.Threading.Tasks;

namespace StockTrader.Domain.Services.Transactions
{
    public class StockPurchaseService : IStockPurchaseService
    {
        private readonly IStockPriceService _SPS;
        private readonly IDataService<Account> _AccS;

        public StockPurchaseService(IStockPriceService SPS, IDataService<Account> AccS)
        {
            _SPS = SPS;
            _AccS = AccS;
        }

        public async Task<Account> StockPurchase(Account Buyer, string Symbol, int Qty)
        {
            double StockPrice = await _SPS.GetPrice(Symbol);

            double TranxCost = StockPrice * Qty;

            if ((TranxCost) > Buyer.Balance)
            {
                throw new InsufficientBalanceX(Buyer.Balance, TranxCost);
            }

            AssetTransaction Tranx = new AssetTransaction()
            {
                WhichAccount = Buyer,
                WhichStock = new Stock()
                {
                    PricePerShare = StockPrice,
                    Symbol = Symbol
                },
                DateProcessed = DateTime.Now,
                Shares = Qty,
                IsPurchase = true
            };

            Buyer.AssetTransactions.Add(Tranx);
            Buyer.Balance -= TranxCost;

            await _AccS.Update(Buyer.Id, Buyer);

            return Buyer;
        }
    }
}
