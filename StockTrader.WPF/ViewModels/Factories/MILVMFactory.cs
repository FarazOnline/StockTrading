using StockTrader.Domain.Services;

namespace StockTrader.WPF.ViewModels.Factories
{
    //Major Index Listing View Model Factory
    public class MILVMFactory : ISTVMFactory<MajorIndexVM>
    {
        private readonly IMajorIndexService _majorIndexService;

        public MILVMFactory(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public MajorIndexVM CreateViewModel()
        {
            return MajorIndexVM.LoadMajorIndexVM(_majorIndexService);
        }
    }
}
