using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CityProcessor.HttpServices.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CityProcessor.HttpServices
{
    public class FakeExternalCityRegistryService
    {
        private readonly HttpClient _httpClient;

        public FakeExternalCityRegistryService(
            HttpClient client,
            IConfiguration configuration)
        {
            var fakeExternalCityRegistryBaseUrl = configuration
                .GetValue<string>("FakeExternalCityRegistryBaseUrl");

            if (string.IsNullOrEmpty(fakeExternalCityRegistryBaseUrl))
                // TODO: Log warning.
                return;

            _httpClient = client;
            _httpClient.BaseAddress = new Uri(fakeExternalCityRegistryBaseUrl);
        }

        public async Task<string> PostRegisterCity(CityModel cityModel)
        {
            if (_httpClient == null)
                return null;

            var requestBody = JsonConvert.SerializeObject(cityModel);

            var response = await _httpClient.PostAsync("register-city",
                new StringContent(requestBody, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var registryCityId = await response.Content.ReadAsStringAsync();

            return registryCityId;
        }
    }
}