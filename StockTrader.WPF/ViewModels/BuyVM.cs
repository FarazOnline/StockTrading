using StockTrader.Domain.Services;
using StockTrader.Domain.Services.Transactions;
using StockTrader.WPF.Commands;
using System.Windows.Input;

namespace StockTrader.WPF.ViewModels
{
    public class BuyVM : BaseVM
    {
        private string _Symbol;
        public string Symbol
        {
            get
            {
                return _Symbol;
            }
            set
            {
                _Symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }

        private string _SrchResSymb = string.Empty;

        public string SrchResSymb
        {
            get
            {
                return _SrchResSymb;
            }
            set
            {
                _SrchResSymb = value;
                OnPropertyChanged(nameof(SrchResSymb));
            }
        }


        private double _StkPr;

        public double StkPr
        {
            get
            {
                return _StkPr;
            }
            set
            {
                _StkPr = value;
                OnPropertyChanged(nameof(StkPr));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        private int _Shrs2Buy;

        public int Shrs2Buy
        {
            get
            {
                return _Shrs2Buy;
            }
            set
            {
                _Shrs2Buy = value;
                OnPropertyChanged(nameof(Shrs2Buy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice
        {
            get
            {
                return Shrs2Buy * StkPr;
            }
        }

        public ICommand cmdSearchSymbol { get; set; }
        public ICommand cmdBuyStock { get; set; }

        public BuyVM(IStockPriceService _SPS, IStockPurchaseService _SBS)
        {
            cmdSearchSymbol = new cmdSearchSymbol(this, _SPS);
            cmdBuyStock = new cmdBuyStock(this, _SBS);
        }
    }
}
