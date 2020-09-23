namespace StockTrader.WPF.ViewModels.Factories
{
    //Portfolio View Model Factory
    public class PVMFactory : ISTVMFactory<PortfolioVM>
    {
        public PortfolioVM CreateViewModel()
        {
            return new PortfolioVM();
        }
    }
}
