using Cryptocurrency.Models.CryptocurencyDetail;
using Cryptocurrency.Models.Cryptocurrency;
using Cryptocurrency.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency.Services
{
    public interface IApiService
    {
        Task<List<CryptocurrencyDataModel>> GetCryptocurrencies();
        Task<CryptocurrencyDetailModel> GetCryptocurrencyDetails(string coinId);
    }
}
