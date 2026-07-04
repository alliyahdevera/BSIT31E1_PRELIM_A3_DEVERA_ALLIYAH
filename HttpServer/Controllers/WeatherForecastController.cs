using Microsoft.AspNetCore.Mvc;

namespace HttpServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<WeatherForecast> GetID(int id)
        {
            var forecast = new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(id)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            };

            return Ok(forecast);
        }

        [HttpPost]
        public IActionResult PostOrSomething([FromBody]WeatherForecast forecast)
        {
            return Ok (forecast);
        }

        [HttpPut("put/{id}")]
        public IActionResult PutMethod(int id, [FromBody] WeatherForecast forecast)
        {
            return Ok(forecast);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteMethod(int id)
        {
            return Ok($"Deleted WeatherForecast with ID = {id}");
        }

    }
}

