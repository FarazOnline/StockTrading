namespace StockTrader.WPF.ViewModels
{
    public class HomeVM : BaseVM
    {
        public MajorIndexVM MIVM { get; set; }
        public HomeVM(MajorIndexVM _MIVM)
        {
            MIVM = _MIVM;
        }
    }
}
