using System.Globalization;
using WeatherApp.Api.Models;
using WeatherApp.Api.Services.Interfaces;

namespace WeatherApp.Api.Services;

public class DateParserService : IDateParserService
{
    private readonly string[] _supportedFormats =
    {
        "MM/dd/yyyy",
        "MMMM d, yyyy",
        "MMM-dd-yyyy"
    };

    public DateParseResult Parse(string dateText)
    {
        if (DateTime.TryParseExact(
                dateText,
                _supportedFormats,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out DateTime parsedDate))
        {
            return new DateParseResult
            {
                IsValid = true,
                OriginalDate = dateText,
                NormalizedDate = parsedDate.ToString("yyyy-MM-dd")
            };
        }

        return new DateParseResult
        {
            IsValid = false,
            OriginalDate = dateText,
            ErrorMessage = "Invalid date"
        };
    }
}