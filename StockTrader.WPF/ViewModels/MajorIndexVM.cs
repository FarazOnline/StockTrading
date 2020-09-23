using StockTrader.Domain.Models;
using StockTrader.Domain.Services;

namespace StockTrader.WPF.ViewModels
{
    public class MajorIndexVM : BaseVM
    {
        private readonly IMajorIndexService _majorIndexService;
        
        private MajorIndex _dj;
        public MajorIndex DowJones
        {
            get
            {
                return _dj;
            }
            set
            {
                _dj = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        private MajorIndex _nd;
        public MajorIndex Nasdaq
        {
            get
            {
                return _nd;
            }
            set
            {
                _nd = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }

        private MajorIndex _sp;
        public MajorIndex SP500
        {
            get
            {
                return _sp;
            }
            set
            {
                _sp = value;
                OnPropertyChanged(nameof(SP500));
            }
        }

        public MajorIndexVM(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexVM LoadMajorIndexVM(IMajorIndexService majorIndexService)
        {
            MajorIndexVM majorIndexVM = new MajorIndexVM(majorIndexService);
            majorIndexVM.LoadMajorIndexes();
            return majorIndexVM;
        }

        private void LoadMajorIndexes()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    DowJones = task.Result;
                }
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    Nasdaq = task.Result;
                }
            });
            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(task =>
            {
                if (task.Exception == null)
                {
                    SP500 = task.Result;
                }
            });
        }
    }
}
