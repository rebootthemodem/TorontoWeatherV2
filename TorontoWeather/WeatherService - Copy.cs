using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TorontoWeather
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://api.open-meteo.com/v1/forecast";

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> GetTorontoWeatherAsync()
        {
            var url = $"{BaseUrl}?latitude=43.7&longitude=-79.42&daily=temperature_2m_max&timezone=America%2FToronto";
            var response = await _httpClient.GetStringAsync(url);
            var weatherData = JObject.Parse(response);
            return weatherData.ToString();
        }
    }
}
