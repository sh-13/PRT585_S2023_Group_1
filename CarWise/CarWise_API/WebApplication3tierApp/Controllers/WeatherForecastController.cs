using _1CommonInfrastructure.Interfaces;
using _1CommonInfrastructure.Services;
using _3BusinessLogicLayer.Interfaces;
using _3BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3tierApp.Controllers
{    
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class WeatherForecastController : BaseController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ILoggingService _loggingService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, ILoggingService loggingService) 
        {
            _logger = logger;
            _loggingService = loggingService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}