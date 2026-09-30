using System.Text.Json.Serialization;

namespace WeatherApp.Api.Models;

public class OpenMeteoResponse
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; } = string.Empty;

    [JsonPropertyName("timezone_abbreviation")]
    public string TimezoneAbbreviation { get; set; } = string.Empty;

    [JsonPropertyName("elevation")]
    public double Elevation { get; set; }

    [JsonPropertyName("daily_units")]
    public DailyUnits DailyUnits { get; set; } = new();

    [JsonPropertyName("daily")]
    public Daily Daily { get; set; } = new();
}