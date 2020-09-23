using StockTrader.Domain.Services;
using StockTrader.WPF.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace StockTrader.WPF.Commands
{
    public class cmdSearchSymbol : ICommand
    {
        private BuyVM _BVM;
        private IStockPriceService _SPS;

        public event EventHandler CanExecuteChanged;

        public cmdSearchSymbol(BuyVM BVM, IStockPriceService SPS)
        {
            _BVM = BVM;
            _SPS = SPS;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                double SPr = await _SPS.GetPrice(_BVM.Symbol);
                _BVM.SrchResSymb = _BVM.Symbol.ToUpper();
                _BVM.StkPr = SPr;
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }
    }
}
