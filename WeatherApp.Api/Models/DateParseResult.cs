namespace WeatherApp.Api.Models;

public class DateParseResult
{
    public bool IsValid { get; set; }

    public string OriginalDate { get; set; } = string.Empty;

    public string? NormalizedDate { get; set; }

    public string? ErrorMessage { get; set; }
}