using WeatherApp.Api.Models;

namespace WeatherApp.Api.Services.Interfaces;

public interface IWeatherService
{
    Task<List<WeatherRecord>> GetWeatherDataAsync();
}