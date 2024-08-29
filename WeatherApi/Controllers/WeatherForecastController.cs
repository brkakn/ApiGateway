using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;

namespace WeatherApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Cities =
    [
        "İstanbul", "Bursa", "Çankırı", "Konya", "Ardahan", "Ordu", "Giresun", "Adana", "Sivas", "İzmir"
    ];

    [HttpGet("getforecast/{id}")]
    public IEnumerable<WeatherForecast> GetForecast(int id)
    {
        List<WeatherForecast> weatherForecasts = [];
        var rng = new Random();
        int i = 0;
        while (i < 30)
        {
            weatherForecasts.Add(new()
            {
                Date = DateTime.Now.AddDays(i),
                TemperatureC = rng.Next(-20, 55),
                City = Cities[id]
            });
            i++;
        }
        return weatherForecasts;
    }
}
