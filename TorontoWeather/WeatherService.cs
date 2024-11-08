using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TorontoWeather
{
    /// <summary>
    /// The WeatherService class provides functionality to fetch weather information for Toronto using the Open-Meteo API.
    /// </summary>
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        // Base URL for the Open-Meteo API
        private const string BaseUrl = "https://api.open-meteo.com/v1/forecast";

        /// <summary>
        /// Initializes a new instance of the WeatherService class and creates an HttpClient instance for making HTTP requests.
        /// </summary>
        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        /// <summary>
        /// Asynchronously retrieves the weather data for Toronto from the Open-Meteo API.
        /// </summary>
        /// <returns>A string containing the JSON response from the API.</returns>
        public async Task<string> GetTorontoWeatherAsync()
        {
            // Build the URL with query parameters for latitude, longitude, and required data (daily max temperature and timezone)
            var url = $"{BaseUrl}?latitude=43.7&longitude=-79.42&daily=temperature_2m_max&timezone=America%2FToronto";

            // Send an asynchronous GET request to the API and retrieve the response as a string
            var response = await _httpClient.GetStringAsync(url);

            // Parse the JSON response string into a JObject for easier manipulation or data extraction
            var weatherData = JObject.Parse(response);

            // Pass the parsed weather data to another method for extraction
            var daysAndTemperatures = ExtractMaxTemperaturesAndDays(weatherData);

            // Format the extracted data as a string and return it
            return daysAndTemperatures;
        }

        /// <summary>
        /// Extracts the daily maximum temperatures, corresponding days, and day names from the weather data.
        /// </summary>
        /// <param name="weatherData">The weather data as a JObject.</param>
        /// <returns>A formatted string with days, day names, and their corresponding maximum temperatures.</returns>
        public string ExtractMaxTemperaturesAndDays(JObject weatherData)
        {
            // Extract the days and daily maximum temperatures from the JSON
            var days = weatherData["daily"]["time"].ToObject<string[]>();
            var maxTemperatures = weatherData["daily"]["temperature_2m_max"].ToObject<double[]>();

            // Build a formatted string with day and temperature pairs
            var result = "";
            for (int i = 0; i < days.Length; i++)
            {
                // Convert the date string to DateTime to get the day of the week
                var date = DateTime.Parse(days[i]);
                var dayName = date.ToString("dddd"); // Gets the full day name (e.g., "Monday")

                result += $"{days[i]} ({dayName}): {maxTemperatures[i]}°C\n";
            }

            return result;
        }
    }
}
