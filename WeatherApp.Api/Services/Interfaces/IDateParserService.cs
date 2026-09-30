using WeatherApp.Api.Models;

namespace WeatherApp.Api.Services.Interfaces;

public interface IDateParserService
{
    DateParseResult Parse(string dateText);
}