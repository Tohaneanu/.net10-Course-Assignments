using Microsoft.AspNetCore.Mvc;
using Weather_App.Models;

namespace Weather_App.Controllers
{
    [Route("")]
    public class WeatherController : Controller
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

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(_weatherData);
        }

        [HttpGet("/weather/{cityCode}")]
        public IActionResult CityWeather(string cityCode)
        {
            CityWeather? city = _weatherData.FirstOrDefault(c => c.CityUniqueCode.Equals(cityCode, StringComparison.OrdinalIgnoreCase));
            if (city == null) {
                ViewBag.ErrorMessage = "Invalid city code supplied.";
                return View("Error");
            }
            return View(city);
        }
    }
}
