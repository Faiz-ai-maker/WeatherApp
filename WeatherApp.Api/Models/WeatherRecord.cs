namespace WeatherApp.Api.Models;

public class WeatherRecord
{
    public string Date { get; set; } = string.Empty;

    public double? MinTemperature { get; set; }

    public double? MaxTemperature { get; set; }

    public double? Precipitation { get; set; }

    public string Status { get; set; } = "Success";

    public string? ErrorMessage { get; set; }
}