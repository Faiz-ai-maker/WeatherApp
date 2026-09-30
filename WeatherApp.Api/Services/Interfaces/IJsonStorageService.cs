using WeatherApp.Api.Models;

namespace WeatherApp.Api.Services.Interfaces;

public interface IJsonStorageService
{
    Task SaveAsync(string fileName, WeatherRecord data);
    Task<WeatherRecord?> ReadAsync(string fileName);
    bool Exists(string fileName);
}