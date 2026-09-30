using Microsoft.AspNetCore.Mvc;
using WeatherApp.Api.Services.Interfaces;

namespace WeatherApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(
        IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result =
            await _weatherService.GetWeatherDataAsync();

        return Ok(result);
    }
}