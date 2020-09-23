using StockTrader.Domain.Models;
using StockTrader.Domain.Services.Transactions;
using StockTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace StockTrader.WPF.Commands
{
    public class cmdBuyStock : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private BuyVM _BVM;
        private IStockPurchaseService _SPS;

        public cmdBuyStock(BuyVM BVM, IStockPurchaseService SPS)
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
                Account account = await _SPS.StockPurchase(new Account()
                {
                    Id = 1,
                    Balance = 50000,
                    AssetTransactions = new List<AssetTransaction>()
                }, _BVM.Symbol, _BVM.Shrs2Buy);
            }
            catch (Exception f)
            {
                MessageBox.Show(f.Message);
            }
        }
    }
}
