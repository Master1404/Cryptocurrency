using Cryptocurrency.Models.CryptocurencyDetail;
using Cryptocurrency.Models.Cryptocurrency;
using Cryptocurrency.Services;
using Cryptocurrency.Views;
using Newtonsoft.Json;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cryptocurrency.ViewModels
{
    public class CryptoDetailViewModel : BaseViewModel
    {
        private string _cryptocurrencyId;
        private INavigationService _navigationService;
        private IApiService _apiService;
        public CryptoDetailViewModel(INavigationService navigationService)
        {
            _apiService = new ApiService();
            _detailViewModel = new CryptocurrencyDetailViewModel();
            _navigationService = navigationService;
            _cryptocurrencyId = string.Empty;
        }

        private CryptocurrencyDataViewModel _selectedCryptocurrency;

        public CryptocurrencyDataViewModel SelectedCryptocurrency
        {
            get => _selectedCryptocurrency;
            set => SetProperty(ref _selectedCryptocurrency, value);
        }

        private string _name;
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _rank;
        [JsonProperty("rank")]
        public string Rank
        {
            get => _rank;
            set => SetProperty(ref _rank, value);
        }

        private CryptocurrencyDetailViewModel _detailViewModel;
        public CryptocurrencyDetailViewModel DetailViewModel
        {
            get => _detailViewModel;
            set => SetProperty(ref _detailViewModel, value);
        }

        private string _symbol;
        public string Symbol
        {
            get => _symbol;
            set => SetProperty(ref _symbol, value);
        }

        private decimal _priceUsd;
        public decimal PriceUsd
        {
            get => _priceUsd;
            set => SetProperty(ref _priceUsd, value);
        }

        private decimal _marketCapUsd;
        public decimal MarketCapUsd
        {
            get => _marketCapUsd;
            set => SetProperty(ref _marketCapUsd, value);
        }

        private decimal _volumeUsd24Hr;
        public decimal VolumeUsd24Hr
        {
            get => _volumeUsd24Hr;
            set => SetProperty(ref _volumeUsd24Hr, value);
        }

        private decimal _changePercent24Hr;
        public decimal ChangePercent24Hr
        {
            get => _changePercent24Hr;
            set => SetProperty(ref _changePercent24Hr, value);
        }


        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            

            if (parameters.ContainsKey("id"))
            {
                string cryptocurrencyId = parameters.GetValue<string>("id");
                await LoadDetailCryptocurrency(cryptocurrencyId);
            }
        }


        private async Task LoadDetailCryptocurrency(string cryptocurrencyId)
        {
            
            var result = await _apiService.GetCryptocurrencyDetails(cryptocurrencyId);

            if (result != null)
            {
                Name = result.Name;
                Rank = result.Rank;
                Symbol = result.Symbol;
                if (decimal.TryParse(result.PriceUsd, out decimal price))
                {
                    PriceUsd = price;
                }
                if(decimal.TryParse(result.MarketCapUsd,out decimal marketCapUsd)) 
                {
                    MarketCapUsd = marketCapUsd;
                }
                if (decimal.TryParse(result.VolumeUsd24Hr, out decimal volumeUsd24Hr))
                {
                    VolumeUsd24Hr = volumeUsd24Hr;
                }
                if (decimal.TryParse(result.ChangePercent24Hr, out decimal changePercent24Hr))
                {
                    ChangePercent24Hr = changePercent24Hr;
                }


                // Update other properties as needed

                RaisePropertyChanged(nameof(Name));
                RaisePropertyChanged(nameof(Rank));
            }

        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            /* if (parameters.ContainsKey("cryptocurrency"))
             {
                 // SelectedCryptocurrency = parameters.GetValue<CryptocurrencyDataViewModel>("cryptocurrency");
                 _cryptocurrencyId = parameters.GetValue<string>("id");
             }*/

            if (parameters.ContainsKey("id"))
            {
                string cryptocurrencyId = parameters.GetValue<string>("id");
                LoadDetailCryptocurrency(cryptocurrencyId);
            }
        }
    }
}