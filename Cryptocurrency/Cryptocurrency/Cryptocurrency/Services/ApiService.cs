using Cryptocurrency.Models.Cryptocurrency;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency.Services
{
    public class ApiService : IApiService
    {
        private HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CryptocurrencyDataModel>> GetCryptocurrencies()
        {
            string apiUrl = "https://api.coincap.io/v2/assets";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    CryptocurrencyDataResponse responseModel = JsonConvert.DeserializeObject<CryptocurrencyDataResponse>(jsonResponse);

                    if (responseModel != null && responseModel.Data != null)
                    {
                        List<CryptocurrencyDataModel> cryptocurrencyModels = responseModel.Data.ConvertAll(c => new CryptocurrencyDataModel
                        {
                            Id = c.Id,
                            Rank = c.Rank,
                            Symbol = c.Symbol,
                            Name = c.Name,
                            Supply = c.Supply,
                            MaxSupply = c.MaxSupply,
                            MarketCapUsd = c.MarketCapUsd,
                            VolumeUsd24Hr = c.VolumeUsd24Hr,
                            PriceUsd = c.PriceUsd,
                            ChangePercent24Hr = c.ChangePercent24Hr,
                            Vwap24Hr = c.Vwap24Hr
                        });

                        return cryptocurrencyModels;
                    }
                }
                else
                {
                    // Обработка ошибки, если запрос не удался
                    Console.WriteLine($"Ошибка при выполнении запроса: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения, если возникла ошибка при выполнении запроса
                Console.WriteLine($"Ошибка при выполнении запроса: {ex.Message}");
            }

            return null;
        }
    }
}