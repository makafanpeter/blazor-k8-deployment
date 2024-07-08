using Microsoft.AspNetCore.SignalR;
using WeatherApp.Data.Client;

namespace WeatherApp.Infrastructure.Services.Hubs;

public class WeatherHub: Hub
{
    private readonly IOpenWeatherMapClient _openWeatherMapClient;
    private readonly ILogger<WeatherHub> _logger;

    public WeatherHub(IOpenWeatherMapClient openWeatherMapClient, ILogger<WeatherHub> logger)
    {
        _openWeatherMapClient = openWeatherMapClient;
        _logger = logger;
    }
    public async Task SendMessage(string user, string message)
    {
        WeatherResponse? weatherResponse = null;
        try
        {
          weatherResponse=  await _openWeatherMapClient.WeatherAsync(message);
        }
        catch (Exception exception)
        {
           _logger.LogError(exception, "{Message}" , exception.Message);
            
        }
        await Clients.Caller.SendAsync("ReceiveMessage", user, weatherResponse);
    }
}