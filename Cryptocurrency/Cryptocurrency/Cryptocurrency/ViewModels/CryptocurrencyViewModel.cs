using Cryptocurrency.Models.Cryptocurrency;
using Cryptocurrency.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Cryptocurrency.ViewModels
{
    public class CryptocurrencyViewModel : INotifyPropertyChanged  // BindableBase INotifyPropertyChanged
    {
        private CryptocurrencyDataViewModel _cryptocurrencyModel;
        private IApiService _apiService;
        public CryptocurrencyViewModel ViewModel { get; set; }
        public CryptocurrencyViewModel(/*IApiService apiService*/)
        {
            _apiService = new ApiService();
            _cryptocurrencyModel = new CryptocurrencyDataViewModel();
           // _apiService = apiService;
            LoadCryptocurrenciesAsync();
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
        }

        private ObservableCollection<CryptocurrencyDataViewModel> _cryptocurrencies;
        public ObservableCollection<CryptocurrencyDataViewModel> Cryptocurrencies
        {
            get => _cryptocurrencies;
            set
            {
                _cryptocurrencies = value;
                OnPropertyChanged(nameof(Cryptocurrencies));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
