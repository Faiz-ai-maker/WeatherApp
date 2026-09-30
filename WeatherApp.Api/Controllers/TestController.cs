using Microsoft.AspNetCore.Mvc;
using WeatherApp.Api.Services.Interfaces;

namespace WeatherApp.Api.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IOpenMeteoService _weatherService;

    public TestController(
        IOpenMeteoService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result =
            await _weatherService.GetWeatherAsync(
                new DateTime(2021, 2, 27));

        return Ok(result);
    }
}