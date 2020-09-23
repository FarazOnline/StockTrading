using StockTrader.WPF.Commands;
using StockTrader.WPF.Models;
using StockTrader.WPF.ViewModels;
using StockTrader.WPF.ViewModels.Factories;
using System.Windows.Input;

namespace StockTrader.WPF.State.Navigators
{
    public class Navigator : ObsrvObj, INavigator
    {
        private BaseVM _CurrentVM;
        public BaseVM CurrentVM
        {
            get
            {
                return _CurrentVM;
            }
            set
            {
                _CurrentVM = value;
                OnPropertyChanged(nameof(CurrentVM));
            }
        }
        public ICommand cmdUpdateCurrVM { get; set; }
        public Navigator(IRSTVMFactory VMFactory)
        {
            cmdUpdateCurrVM = new cmdUpdateCurrVM(this, VMFactory);
        }
    }
}
