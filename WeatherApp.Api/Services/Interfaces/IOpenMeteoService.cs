using WeatherApp.Api.Models;

namespace WeatherApp.Api.Services.Interfaces;

public interface IOpenMeteoService
{
    Task<WeatherRecord> GetWeatherAsync(DateTime date);
}