using GenericRepositoryPatternWebAPI.Models;
using GenericRepositoryPatternWebAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPatternWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            var result = Enumerable.Range(1, 25).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Constant.Summaries[Random.Shared.Next(Constant.Summaries.Length)]
            }).ToArray();
            _logger.LogInformation(await Task.FromResult($"Generated {result.Length} weather forecasts"));
            return Ok(await Task.FromResult(result));
        }
    }
}
