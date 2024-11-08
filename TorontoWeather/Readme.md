# TorontoWeather

The `TorontoWeather` project contains a `WeatherService` class that fetches weather information for Toronto using the Open-Meteo API. This service retrieves the daily maximum temperatures for Toronto and includes the corresponding day names for each temperature.

## Features

- Fetches weather data asynchronously using the Open-Meteo API.
- Retrieves daily maximum temperatures for Toronto.
- Includes the day of the week (e.g., Monday, Tuesday) for each temperature.
- Parses the JSON response with `Newtonsoft.Json` (JObject) for easier data manipulation.

## Requirements

- .NET 5 or later.
- Internet access to fetch data from the Open-Meteo API.
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/) for JSON parsing.

## Getting Started

### Install Dependencies

Before using the `WeatherService` class, ensure that your project includes the necessary dependencies. Install `Newtonsoft.Json` via NuGet:

```bash
dotnet add package Newtonsoft.Json

### Example Usage
using System;
using System.Threading.Tasks;

namespace TorontoWeather
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var weatherService = new WeatherService();
            var weatherData = await weatherService.GetTorontoWeatherAsync();

            Console.WriteLine($"Toronto Weather Data:\n{weatherData}");
        }
    }
}

###How it works
WeatherService Constructor: Initializes the HttpClient used to send HTTP requests.

GetTorontoWeatherAsync() Method:

Constructs the URL with the appropriate query parameters for latitude, longitude, daily max temperature, and timezone.
Sends an asynchronous GET request to fetch weather data in JSON format.
Returns a formatted string with the dates, day names, and corresponding maximum temperatures.
ExtractMaxTemperaturesAndDays() Method:

Extracts the daily maximum temperatures and the corresponding days from the parsed JSON response.
Converts the date string to a DateTime object to determine the day of the week.
Builds a formatted string that displays each date, its day of the week, and its corresponding maximum temperature in Celsius.

###Sample Output
Toronto Weather Data:
2024-11-08 (Friday): 12.3°C
2024-11-09 (Saturday): 13.5°C
2024-11-10 (Sunday): 14.6°C
2024-11-11 (Monday): 15.2°C
2024-11-12 (Tuesday): 16.1°C

###API Details
The service uses the Open-Meteo API to fetch weather data. Specifically, it requests:

latitude: 43.7 (Toronto's latitude).
longitude: -79.42 (Toronto's longitude).
daily: temperature_2m_max (daily maximum temperature).
timezone: America/Toronto (to get the weather data in the Toronto timezone).
For more information on the Open-Meteo API, visit the Open-Meteo Documentation.

###Contributing
Contributions are welcome! If you have suggestions or improvements for this service, feel free to fork this repository and submit a pull request.

###License
This project is licensed under the MIT License - see the LICENSE file for details.


This `README.md` outlines the new features of the `WeatherService` class, highlighting the inclusion of day names alongside maximum temperatures. It includes the setup instructions, example usage, and sample output. Let me know if you need further modifications or additions!
