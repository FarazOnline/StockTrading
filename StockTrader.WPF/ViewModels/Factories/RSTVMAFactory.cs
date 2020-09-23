using StockTrader.WPF.State.Navigators;
using System;

namespace StockTrader.WPF.ViewModels.Factories
{
    //Root Stock Trader View Model Factory
    public class RSTVMAFactory : IRSTVMFactory
    {
        private readonly ISTVMFactory<HomeVM> _HVMF;
        private readonly ISTVMFactory<PortfolioVM> _PVMF;
        private readonly BuyVM _BVM;

        public RSTVMAFactory(ISTVMFactory<HomeVM> hVMF, ISTVMFactory<PortfolioVM> pVMF, BuyVM bVM)
        {
            _HVMF = hVMF;
            _PVMF = pVMF;
            _BVM = bVM;
        }

        public BaseVM CreateVM(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _HVMF.CreateViewModel();
                case ViewType.Portfolio:
                    return _PVMF.CreateViewModel();
                case ViewType.Buy:
                    return _BVM;
                default:
                    throw new ArgumentException("ViewType has no valid ViewModel.", "viewType");
            }
        }
    }
}
