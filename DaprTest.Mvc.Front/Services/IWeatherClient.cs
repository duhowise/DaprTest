﻿using DaprTest.Mvc.Front.Models;

namespace DaprTest.Mvc.Front.Services;

public interface IWeatherClient
{
    Task<IEnumerable<WeatherForecast>?> GetWeather();
}

public class WeatherClient:IWeatherClient
{
    private readonly HttpClient _httpClient;

    public WeatherClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
    public async Task<IEnumerable<WeatherForecast>?> GetWeather()
    {
        return await _httpClient.
            GetFromJsonAsync<IEnumerable<WeatherForecast>>("/weatherforecast");
    }
}