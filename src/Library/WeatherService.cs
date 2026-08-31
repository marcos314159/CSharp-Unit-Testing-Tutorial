using System.Globalization;

namespace Library;

public record WeatherData(string City, double TemperatureCelsius, string Condition);

public interface IWeatherApiClient
{
    Task<WeatherData?> GetWeatherAsync(string city);
    Task<IEnumerable<WeatherData>> GetForecastAsync(string city, int days);
}

/// <summary>
/// Weather service used to demonstrate async/await test patterns.
/// </summary>
public class WeatherService(IWeatherApiClient apiClient)
{
    public async Task<string> GetWeatherSummaryAsync(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
            throw new ArgumentException("City is required.", nameof(city));

        var data = await apiClient.GetWeatherAsync(city);
        if (data is null) return $"No weather data available for {city}.";

        return $"{data.City}: {data.TemperatureCelsius.ToString(CultureInfo.InvariantCulture)}°C, {data.Condition}";
    }

    public async Task<WeatherData?> GetHottestForecastDayAsync(string city, int days)
    {
        var forecast = await apiClient.GetForecastAsync(city, days);
        return forecast.MaxBy(w => w.TemperatureCelsius);
    }

    public async Task<bool> IsFreezingAsync(string city)
    {
        var data = await apiClient.GetWeatherAsync(city);
        return data is not null && data.TemperatureCelsius <= 0;
    }
}
