using Cryptocurrency.Models.CryptocurencyDetail;
using Cryptocurrency.Models.Cryptocurrency;
using Cryptocurrency.Services;
using Cryptocurrency.Views;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Navigation.Xaml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using NavigationParameters = Prism.Navigation.NavigationParameters;

namespace Cryptocurrency.ViewModels
{
    public class CryptocurrencyViewModel : BindableBase
    {
        private IApiService _apiService;
        private INavigationService _navigationService;
        public ICommand SearchCommand { get; }
        public ICommand ShowDetailsCommand { get; }
        public CryptocurrencyViewModel(INavigationService navigationService, IApiService apiService)
        {
            _filteredCryptocurrencies = new ObservableCollection<CryptocurrencyDataViewModel>();
            Cryptocurrencies = new ObservableCollection<CryptocurrencyDataViewModel>();
            _apiService = apiService;
            SearchCommand = new Command(ExecuteSearch);
            ShowDetailsCommand = new Command(ShowDetails);
            _navigationService = navigationService;
            LoadCryptocurrenciesAsync();

           // SelectedCryptocurrencyId = "bitcoin";
        }

        private CryptocurrencyDataViewModel _selectedCryptocurrency;
        public CryptocurrencyDataViewModel SelectedCryptocurrency
        {
            get => _selectedCryptocurrency;
            set
            {
                SetProperty(ref _selectedCryptocurrency, value);
                if (_selectedCryptocurrency != null)
                {
                    SelectedCryptocurrencyId = _selectedCryptocurrency.Id;
                }
            }
        }

        private string _selectedCryptocurrencyId;
        public string SelectedCryptocurrencyId
        {
            get => _selectedCryptocurrencyId;
            set => SetProperty(ref _selectedCryptocurrencyId, value);
        }


        private async void ShowDetails()
        {
             if (SelectedCryptocurrencyId != null)
             {
                 var navigationParams = new NavigationParameters
                 {
                     { "id", SelectedCryptocurrency.Id }
                 };

                 await _navigationService.NavigateAsync("CryptocurrencyDetails", navigationParams);
             }
        }

        private async void LoadCryptocurrenciesAsync()
        {    
            List<CryptocurrencyDataModel> result = await _apiService.GetCryptocurrencies();
            List<CryptocurrencyDataViewModel> cryptocurrencies = new List<CryptocurrencyDataViewModel>();

            foreach (var data in result)
            {
                CryptocurrencyDataViewModel viewModel = new CryptocurrencyDataViewModel();
                viewModel.Id = data.Id;
                viewModel.Name = data.Name;
                viewModel.PriceUsd = data.PriceUsd;
                viewModel.Symbol = data.Symbol;

                cryptocurrencies.Add(viewModel);
            }
            Cryptocurrencies = new ObservableCollection<CryptocurrencyDataViewModel>(cryptocurrencies);
            _filteredCryptocurrencies.Clear();

            foreach (var cryptocurrency in Cryptocurrencies)
            {
                _filteredCryptocurrencies.Add(cryptocurrency);
            }
        }


        private ObservableCollection<CryptocurrencyDataViewModel> _cryptocurrencies;
        public ObservableCollection<CryptocurrencyDataViewModel> Cryptocurrencies
        {
            get => _cryptocurrencies;
            set => SetProperty(ref _cryptocurrencies, value);
        }

        private ObservableCollection<CryptocurrencyDataViewModel> _filteredCryptocurrencies;
        public ObservableCollection<CryptocurrencyDataViewModel> FilteredCryptocurrencies
        {
            get => _filteredCryptocurrencies;
            set => SetProperty(ref _filteredCryptocurrencies, value);
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        private void ExecuteSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Cryptocurrencies.Clear();

                foreach (var cryptocurrency in _filteredCryptocurrencies)
                {
                    Cryptocurrencies.Add(cryptocurrency);
                }
            }

            else
            {
                Cryptocurrencies.Clear();

                foreach (var cryptocurrency in _filteredCryptocurrencies)
                {
                    if (cryptocurrency.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        cryptocurrency.Symbol.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        Cryptocurrencies.Add(cryptocurrency);
                    }
                }
            }
        }
    }
}
