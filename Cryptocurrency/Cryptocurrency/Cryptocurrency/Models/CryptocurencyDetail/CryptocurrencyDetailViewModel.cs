using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Cryptocurrency.Models.CryptocurencyDetail
{
    public class CryptocurrencyDetailViewModel : BindableBase
    {
        private CryptocurrencyDetailModel _detailModel;

        public CryptocurrencyDetailViewModel()
        {
            _detailModel = new CryptocurrencyDetailModel();
        }
        private string _id;
        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        private string _rank;
        [JsonProperty("rank")]
        public string Rank
        {
            get => _rank;
            set => SetProperty(ref _rank, value);
        }

        private string _symbol;
        [JsonProperty("symbol")]
        public string Symbol
        {
            get => _symbol;
            set => SetProperty(ref _symbol, value);
        }

        private string _name;
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _supply;
        [JsonProperty("supply")]
        public string Supply
        {
            get => _supply;
            set => SetProperty(ref _supply, value);
        }

        private string _maxSupply;
        [JsonProperty("maxSupply")]
        public string MaxSupply
        {
            get => _maxSupply;
            set => SetProperty(ref _maxSupply, value);
        }

        private string _marketCapUsd;
        [JsonProperty("marketCapUsd")]
        public string MarketCapUsd
        {
            get => _marketCapUsd;
            set => SetProperty(ref _marketCapUsd, value);
        }

        private string _volumeUsd24Hr;
        [JsonProperty("volumeUsd24Hr")]
        public string VolumeUsd24Hr
        {
            get => _volumeUsd24Hr;
            set => SetProperty(ref _volumeUsd24Hr, value);
        }

        private string _priceUsd;
        [JsonProperty("priceUsd")]
        public string PriceUsd
        {
            get => _priceUsd;
            set => SetProperty(ref _priceUsd, value);
        }

        private string _changePercent24Hr;
        [JsonProperty("changePercent24Hr")]
        public string ChangePercent24Hr
        {
            get => _changePercent24Hr;
            set => SetProperty(ref _changePercent24Hr, value);
        }

        private string _vwap24Hr;
        [JsonProperty("vwap24Hr")]
        public string Vwap24Hr
        {
            get => _vwap24Hr;
            set => SetProperty(ref _vwap24Hr, value);
        }
    }
}
