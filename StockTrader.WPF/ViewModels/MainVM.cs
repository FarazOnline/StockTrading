using StockTrader.WPF.State.Navigators;

namespace StockTrader.WPF.ViewModels
{
    public class MainVM : BaseVM
    {
        public INavigator Navigator { get; set; }
        public MainVM(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.cmdUpdateCurrVM.Execute(ViewType.Home);
        }
    }
}
