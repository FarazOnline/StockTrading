﻿using StockTrader.WPF.ViewModels;
using System.Windows.Input;

namespace StockTrader.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Buy
    }

    public interface INavigator
    {
        BaseVM CurrentVM { get; set; }
        ICommand cmdUpdateCurrVM { get; }
    }
}
