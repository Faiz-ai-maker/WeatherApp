using WeatherApp.Api.Models;
using WeatherApp.Api.Services.Interfaces;

namespace WeatherApp.Api.Services;

public class WeatherService : IWeatherService
{
    private readonly IDateParserService _dateParserService;
    private readonly IJsonStorageService _jsonStorageService;
    private readonly IOpenMeteoService _openMeteoService;

    public WeatherService(
        IDateParserService dateParserService,
        IJsonStorageService jsonStorageService,
        IOpenMeteoService openMeteoService)
    {
        _dateParserService = dateParserService;
        _jsonStorageService = jsonStorageService;
        _openMeteoService = openMeteoService;
    }

    public async Task<List<WeatherRecord>> GetWeatherDataAsync()
    {
        var results = new List<WeatherRecord>();

        var filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Data",
            "dates.txt");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(
                "dates.txt file not found.");
        }

        var dates = await File.ReadAllLinesAsync(filePath);

        foreach (var dateText in dates)
        {
            if (string.IsNullOrWhiteSpace(dateText))
                continue;

            var parseResult =
                _dateParserService.Parse(dateText.Trim());

            if (!parseResult.IsValid)
            {
                results.Add(new WeatherRecord
                {
                    Date = dateText,
                    Status = "Invalid Date",
                    ErrorMessage = parseResult.ErrorMessage
                });

                continue;
            }

            var fileName =
                $"{parseResult.NormalizedDate}.json";

            if (_jsonStorageService.Exists(fileName))
            {
                var cachedWeather =
                    await _jsonStorageService.ReadAsync(fileName);

                if (cachedWeather != null)
                {
                    results.Add(cachedWeather);
                    continue;
                }
            }

            var weather =
                await _openMeteoService.GetWeatherAsync(
                    DateTime.Parse(parseResult.NormalizedDate!));

            await _jsonStorageService.SaveAsync(
                fileName,
                weather);

            results.Add(weather);
        }

        return results;
    }
}