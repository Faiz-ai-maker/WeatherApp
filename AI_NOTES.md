# AI_NOTES.md

## AI Tools Used

- GitHub Copilot
- ChatGPT
- Visual Studio IntelliSense

## Helpful Prompts

### Prompt 1
Design a .NET 8 Web API using Dependency Injection to read dates from a text file, call the Open-Meteo API, cache results as JSON files, and expose a REST endpoint.

### Prompt 2
Generate Angular components to display weather data in a table with sorting, filtering, loading indicators, and error handling.

### Prompt 3
Create clean architecture and service layer separation for parsing dates, storing JSON files, and consuming external APIs.

## Example Where AI Suggestion Was Not Ideal

Initially, AI generated DTOs based on the Open-Meteo hourly weather response. After testing the API, I realized the coding exercise required daily weather fields such as minimum temperature, maximum temperature, and precipitation.

I reviewed the actual API response and updated the DTOs and service implementation to use the daily endpoint instead of the hourly endpoint. This simplified the solution and aligned it with the assignment requirements.

## Parts Implemented Manually

I manually reviewed and adjusted:

- Open-Meteo API request parameters
- DTO mapping based on actual API responses
- Date parsing and validation logic
- Angular filtering and sorting behavior
- UI layout and user experience improvements
- Error handling and JSON file caching logic

These changes were made to ensure the solution matched the assignment requirements and behaved correctly when tested.

## AI Usage Summary

AI was used as a productivity tool to accelerate development, generate initial code structures, suggest Angular and .NET implementation patterns, and help troubleshoot issues. All generated code was reviewed, tested, and adjusted where necessary before being included in the final solution.
