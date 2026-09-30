using System.Text.Json;
using WeatherApp.Api.Models;
using WeatherApp.Api.Services.Interfaces;

namespace WeatherApp.Api.Services;

public class OpenMeteoService : IOpenMeteoService
{
    private readonly HttpClient _httpClient;

    public OpenMeteoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherRecord> GetWeatherAsync(DateTime date)
    {
        try
        {
            var dateString = date.ToString("yyyy-MM-dd");

            var requestUrl =
                $"https://archive-api.open-meteo.com/v1/archive" +
                $"?latitude=32.78" +
                $"&longitude=-96.80" +
                $"&start_date={dateString}" +
                $"&end_date={dateString}" +
                $"&daily=temperature_2m_max,temperature_2m_min,precipitation_sum" +
                $"&timezone=auto";

            var response =
                await _httpClient.GetAsync(requestUrl);

            response.EnsureSuccessStatusCode();

            var json =
                await response.Content.ReadAsStringAsync();

            var weatherResponse =
                JsonSerializer.Deserialize<OpenMeteoResponse>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            if (weatherResponse == null ||
                weatherResponse.Daily == null ||
                !weatherResponse.Daily.Time.Any())
            {
                return new WeatherRecord
                {
                    Date = dateString,
                    Status = "Failed",
                    ErrorMessage = "No weather data returned"
                };
            }

            return new WeatherRecord
            {
                Date = weatherResponse.Daily.Time.First(),

                MinTemperature =
                    weatherResponse.Daily.Temperature2mMin.FirstOrDefault(),

                MaxTemperature =
                    weatherResponse.Daily.Temperature2mMax.FirstOrDefault(),

                Precipitation =
                    weatherResponse.Daily.PrecipitationSum.FirstOrDefault(),

                Status = "Success"
            };
        }
        catch (HttpRequestException ex)
        {
            return new WeatherRecord
            {
                Date = date.ToString("yyyy-MM-dd"),
                Status = "Failed",
                ErrorMessage = $"API Error: {ex.Message}"
            };
        }
        catch (TaskCanceledException ex)
        {
            return new WeatherRecord
            {
                Date = date.ToString("yyyy-MM-dd"),
                Status = "Failed",
                ErrorMessage = $"Request Timeout: {ex.Message}"
            };
        }
        catch (Exception ex)
        {
            return new WeatherRecord
            {
                Date = date.ToString("yyyy-MM-dd"),
                Status = "Failed",
                ErrorMessage = ex.Message
            };
        }
    }
}