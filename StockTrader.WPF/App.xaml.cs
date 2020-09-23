using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using StockTrader.API.Services;
using StockTrader.Domain.Models;
using StockTrader.Domain.Services;
using StockTrader.Domain.Services.AuthServices;
using StockTrader.Domain.Services.Transactions;
using StockTrader.EntityFramework;
using StockTrader.EntityFramework.Services;
using StockTrader.WPF.State.Navigators;
using StockTrader.WPF.ViewModels;
using StockTrader.WPF.ViewModels.Factories;
using System;
using System.Windows;

namespace StockTrader.WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs f)
        {
            IServiceProvider SP = CreateServiceProvider();
            //IAuthService authentication = SP.GetRequiredService<IAuthService>();
            //authentication.Login("faq.here", "faq123");

            Window window = SP.GetRequiredService<MainWindow>();
            window.Show();

            base.OnStartup(f);
        }

        private IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<StockTraderDbContextFactory>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<IDataService<Account>, AccountDataService>();
            services.AddSingleton<ILoginService, AccountDataService>();
            services.AddSingleton<IStockPriceService, StockPriceService>();
            services.AddSingleton<IStockPurchaseService, StockPurchaseService>();
            services.AddSingleton<IMajorIndexService, MajorIndexService>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            services.AddSingleton<IRSTVMFactory, RSTVMAFactory>();
            services.AddSingleton<ISTVMFactory<HomeVM>, HVMFactory>();
            services.AddSingleton<ISTVMFactory<PortfolioVM>, PVMFactory>();
            services.AddSingleton<ISTVMFactory<MajorIndexVM>, MILVMFactory>();

            services.AddScoped<INavigator, Navigator>();
            services.AddScoped<MainVM>();
            services.AddScoped<BuyVM>();

            services.AddScoped<MainWindow>(f => new MainWindow(f.GetRequiredService<MainVM>()));

            return services.BuildServiceProvider();
        }
    }
}
