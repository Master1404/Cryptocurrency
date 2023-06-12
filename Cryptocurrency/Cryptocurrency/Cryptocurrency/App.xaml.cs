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
            //containerRegistry.RegisterInstance(UserDialogs.Instance);

            containerRegistry.RegisterInstance<IApiService>(Container.Resolve<ApiService>());

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<CryptocurrencyPage, CryptocurrencyViewModel>();
            containerRegistry.RegisterForNavigation<CryptocurrencyDetails, CryptoDetailViewModel>();

        }

        protected override async void OnInitialized()
        {
            /* InitializeComponent();
             await NavigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(CryptocurrencyPage)}");
            */
            InitializeComponent();

            //var navigationParams = new NavigationParameters();
            Prism.Navigation.NavigationParameters navigationParams = new Prism.Navigation.NavigationParameters();

            // Если вам нужно передать дополнительные параметры в CryptocurrencyPage,
            // вы можете добавить их в navigationParams

            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(CryptocurrencyPage)}", navigationParams);
        }
    }
}
