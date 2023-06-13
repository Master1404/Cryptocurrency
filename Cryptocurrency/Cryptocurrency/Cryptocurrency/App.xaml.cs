using Cryptocurrency.Services;
using Cryptocurrency.ViewModels;
using Cryptocurrency.Views;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using Prism.Unity;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cryptocurrency
{
    public partial class App : PrismApplication
    {
        public static App Instance { get; private set; }
        public static T Resolve<T>() => Current.Container.Resolve<T>();
        public App(
            Prism.IPlatformInitializer initializer = null)
             : base(initializer)
        { 
            Instance = this;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IApiService>(Container.Resolve<ApiService>());
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CryptocurrencyPage, CryptocurrencyViewModel>();
            containerRegistry.RegisterForNavigation<CryptocurrencyDetails, CryptoDetailViewModel>();
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            Prism.Navigation.NavigationParameters navigationParams = new Prism.Navigation.NavigationParameters();
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(CryptocurrencyPage)}", navigationParams);
        }
    }
}
