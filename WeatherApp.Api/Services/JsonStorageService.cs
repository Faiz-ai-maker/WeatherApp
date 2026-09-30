using System.Text.Json;
using WeatherApp.Api.Models;
using WeatherApp.Api.Services.Interfaces;

namespace WeatherApp.Api.Services;

public class JsonStorageService : IJsonStorageService
{
    private readonly string _folderPath;

    public JsonStorageService()
    {
        _folderPath = Path.Combine(Directory.GetCurrentDirectory(), "weather-data");
        Directory.CreateDirectory(_folderPath);
    }

    public bool Exists(string fileName)
    {
        return File.Exists(Path.Combine(_folderPath, fileName));
    }

    public async Task SaveAsync(string fileName, WeatherRecord data)
    {
        var path = Path.Combine(_folderPath, fileName);

        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });

        await File.WriteAllTextAsync(path, json);
    }

    public async Task<WeatherRecord?> ReadAsync(string fileName)
    {
        var path = Path.Combine(_folderPath, fileName);

        if (!File.Exists(path))
            return null;

        var json = await File.ReadAllTextAsync(path);

        return JsonSerializer.Deserialize<WeatherRecord>(json);
    }
}