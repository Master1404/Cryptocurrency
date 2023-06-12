using Cryptocurrency.Models.CryptocurencyDetail;
using Cryptocurrency.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptocurrency.Services
{
    public class CryptocurrencyDetailsApiResponse
    {
        [JsonProperty("data")]
        public CryptocurrencyDetailModel Data { get; set; }
    }
}
