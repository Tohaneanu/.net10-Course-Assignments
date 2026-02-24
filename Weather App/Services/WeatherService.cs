using Models;
using ServiceContracts;

namespace Services
{
    public class WeatherService : IWeatherService
    {
        private readonly List<CityWeather> _weatherData = new()
        {
        new CityWeather
        {
            CityUniqueCode = "LDN",
            CityName = "London",
            DateAndTime = DateTime.Parse("2030-01-01 08:00"),
            TemperatureFahrenheit = 33
        },
        new CityWeather
        {
            CityUniqueCode = "NYC",
            CityName = "New York",
            DateAndTime = DateTime.Parse("2030-01-01 03:00"),
            TemperatureFahrenheit = 60
        },
        new CityWeather
        {
            CityUniqueCode = "PAR",
            CityName = "Paris",
            DateAndTime = DateTime.Parse("2030-01-01 09:00"),
            TemperatureFahrenheit = 82
        }
        };

        public CityWeather? GetWeatherByCityCode(string CityCode)
        {
            return _weatherData.FirstOrDefault(c => c.CityUniqueCode.Equals(CityCode, StringComparison.OrdinalIgnoreCase));
        }

        public List<CityWeather> GetWeatherDetails()
        {
            return _weatherData;
        }
    }
}
