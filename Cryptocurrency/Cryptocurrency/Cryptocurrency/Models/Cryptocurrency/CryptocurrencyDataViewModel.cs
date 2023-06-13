using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Cryptocurrency.Models.Cryptocurrency
{
    public class CryptocurrencyDataViewModel : BindableBase
    {
        private CryptocurrencyDataModel _cryptocurrencyModel;
        public CryptocurrencyDataViewModel()
        { 
            _cryptocurrencyModel = new CryptocurrencyDataModel();
        }

        public string Id
        {
            get { return _cryptocurrencyModel.Id; }
            set
            {
                if (_cryptocurrencyModel.Id != value)
                {
                    _cryptocurrencyModel.Id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        public string Name
        {
            get { return _cryptocurrencyModel.Name; }
            set
            {
                if (_cryptocurrencyModel.Name != value)
                {
                    _cryptocurrencyModel.Name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public string Symbol
        {
            get { return _cryptocurrencyModel.Symbol; }
            set
            {
                if (_cryptocurrencyModel.Symbol != value)
                {
                    _cryptocurrencyModel.Symbol = value;
                    OnPropertyChanged("Symbol");
                }
            }
        }

        public decimal PriceUsd
        {
            get { return _cryptocurrencyModel.PriceUsd; }
            set
            {
                if (_cryptocurrencyModel.PriceUsd != value)
                {
                    _cryptocurrencyModel.PriceUsd = value;
                    OnPropertyChanged("PriceUsd");
                }
            }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get => _searchCommand;
            set => SetProperty(ref _searchCommand, value);
        }

        private ICommand _showDetailsCommand;
        public ICommand ShowDetailsCommand
        {
            get => _showDetailsCommand;
            set => SetProperty(ref _showDetailsCommand, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
