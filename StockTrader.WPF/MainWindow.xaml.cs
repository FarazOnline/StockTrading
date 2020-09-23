using System.Windows;

namespace StockTrader.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow(object DC)
        {
            InitializeComponent();
            DataContext = DC;
        }
    }
}
