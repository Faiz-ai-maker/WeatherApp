using Microsoft.AspNetCore.Mvc;
using WeatherApp.Api.Services.Interfaces;

namespace WeatherApp.Api.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IDateParserService _dateParser;

    public TestController(IDateParserService dateParser)
    {
        _dateParser = dateParser;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var result =
            _dateParser.Parse("June 2");

        return Ok(result);
    }
}