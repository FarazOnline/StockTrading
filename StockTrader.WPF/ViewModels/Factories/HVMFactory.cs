namespace StockTrader.WPF.ViewModels.Factories
{
    //Home View Model Factory
    public class HVMFactory : ISTVMFactory<HomeVM>
    {
        private ISTVMFactory<MajorIndexVM> _MVMF;

        public HVMFactory(ISTVMFactory<MajorIndexVM> MVMF)
        {
            _MVMF = MVMF;
        }

        public HomeVM CreateViewModel()
        {
            return new HomeVM(_MVMF.CreateViewModel());
        }
    }
}
