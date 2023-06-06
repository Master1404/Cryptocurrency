using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Cryptocurrency.Models.Cryptocurrency
{
    public class CryptocurrencyDataViewModel : INotifyPropertyChanged
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


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
