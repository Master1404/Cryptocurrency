using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Models
{
    public class CryptocurrencyDataModel
    {
        public string Id { get; set; }
        public int Rank { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Supply { get; set; }
        public Nullable<decimal> MaxSupply { get; set; }
        public decimal MarketCapUsd { get; set; }
        public decimal VolumeUsd24Hr { get; set; }
        public decimal PriceUsd { get; set; }
        public decimal ChangePercent24Hr { get; set; }
        public Nullable<decimal> Vwap24Hr { get; set; }
    }
}
