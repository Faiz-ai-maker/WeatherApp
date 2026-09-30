# Weather Application

This application fetches historical weather data from the Open-Meteo API and displays it in an Angular UI.

## Backend (.NET 8)

1. Reads dates from `Data/dates.txt`
2. Parses multiple date formats and validates dates
3. Calls Open-Meteo Historical Weather API
4. Stores results as JSON files under `weather-data`
5. Exposes `GET /api/weather` endpoint

### Run Backend
dotnet restore
dotnet run
