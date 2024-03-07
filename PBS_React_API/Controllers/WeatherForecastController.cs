using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PBS_React_API.DatabaseContext.Interface;
using PBS_React_API.Model;
using System.Data;

namespace PBS_React_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly iProjectDataContext _dataContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, iProjectDataContext dataContext)
        {
            _logger = logger;
            _dataContext = dataContext;
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