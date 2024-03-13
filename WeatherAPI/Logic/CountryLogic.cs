using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using WeatherAPI.Model;

namespace WeatherAPI.Logic
{
    public class CountryLogic
    {
        private readonly HttpClient _httpClient;
        public CountryLogic(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Country>> GetCountries()
        {
            try
            {
                // Call the REST Countries API to retrieve a list of countries
                var response = await _httpClient.GetAsync("https://restcountries.com/v3.1/all");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var countries = JsonSerializer.Deserialize<List<Country>>(responseBody);

                    // Check if deserialization succeeded
                    if (countries != null)
                    {
                        return countries;
                    }
                    else
                    {
                        throw new Exception("Failed to deserialize response");
                    }
                }
                else
                {
                    throw new Exception("Failed to retrieve countries");
                }
            }
            catch (HttpRequestException)
            {
                throw new Exception("Failed to connect to the external API");
            }
        }
        public async Task<int> GetCountCountry()
        {
            var allCountries = await GetCountries();
            var count = allCountries.Count();
            return count;
        }

        public async Task<IEnumerable<Country>> GetSpecificCountry(string name)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://restcountries.com/v3.1/name/{name}");

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var country = JsonSerializer.Deserialize<List<Country>>(responseBody);
                return country;
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new HttpRequestException($"Country Not Found! {HttpStatusCode.NotFound}");
            }
            else
            {
                throw new HttpRequestException($"Failed to retrieve country information. Status code: {response.StatusCode}");
            }
        }





    }
}
