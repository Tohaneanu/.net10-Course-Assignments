using Microsoft.AspNetCore.Mvc;
using Models;
using ServiceContracts;

namespace Weather_App.Controllers
{
    [Route("")]
    public class WeatherController : Controller
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(_weatherService.GetWeatherDetails());
        }

        [HttpGet("/weather/{cityCode}")]
        public IActionResult CityWeather(string cityCode)
        {
            CityWeather? city = _weatherService.GetWeatherByCityCode(cityCode);
            if (city == null) {
                ViewBag.ErrorMessage = "Invalid city code supplied.";
                return View("Error");
            }
            return View(city);
        }
    }
}
