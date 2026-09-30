using System.Text.Json.Serialization;

namespace WeatherApp.Api.Models;

public class DailyUnits
{
    [JsonPropertyName("time")]
    public string Time { get; set; } = string.Empty;

    [JsonPropertyName("temperature_2m_max")]
    public string Temperature2mMax { get; set; } = string.Empty;

    [JsonPropertyName("temperature_2m_min")]
    public string Temperature2mMin { get; set; } = string.Empty;

    [JsonPropertyName("precipitation_sum")]
    public string PrecipitationSum { get; set; } = string.Empty;
}