using StockTrader.WPF.State.Navigators;
using StockTrader.WPF.ViewModels.Factories;
using System;
using System.Windows.Input;

namespace StockTrader.WPF.Commands
{
    public class cmdUpdateCurrVM : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IRSTVMFactory _STVMAF;

        public cmdUpdateCurrVM(INavigator navigator, IRSTVMFactory STVMAF)
        {
            _navigator = navigator;
            _STVMAF = STVMAF;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                _navigator.CurrentVM = _STVMAF.CreateVM(viewType);  
            }
        }
    }
}
