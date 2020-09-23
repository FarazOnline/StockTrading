using StockTrader.WPF.State.Navigators;

namespace StockTrader.WPF.ViewModels.Factories
{
    //Interface Root Stock Trader View Model Factory
    public interface IRSTVMFactory
    {
        BaseVM CreateVM(ViewType viewType);
    }
}
