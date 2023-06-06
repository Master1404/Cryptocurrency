using Cryptocurrency.Models.Cryptocurrency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency.Services
{
    public interface IApiService
    {
        Task<List<CryptocurrencyDataModel>> GetCryptocurrencies();
       // Task<List<MarketModel>> GetMarkets();

    }
}
