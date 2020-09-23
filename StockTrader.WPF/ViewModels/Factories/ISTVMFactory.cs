namespace StockTrader.WPF.ViewModels.Factories
{
    //Interface Stock Trader View Model Factory
    public interface ISTVMFactory<T> where T : BaseVM
    {
        T CreateViewModel();
    }
}
