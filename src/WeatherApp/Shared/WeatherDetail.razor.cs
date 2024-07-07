using Microsoft.AspNetCore.Components;
using Serilog;
using WeatherApp.Data.Client;

namespace WeatherApp.Shared;

public partial class WeatherDetail : ComponentBase
{
   

    [Parameter]
    public GeoResponse? SelectedLocation { get; set; }
    
    [Inject]
    private IOpenWeatherMapClient? OpenWeatherMapClient { get; set; }
    
    private WeatherResponse? _weather;
    
    private string? ErrorMessage { get; set; }
    
    // Tracking of asynchronous calls

    private bool _error;

    protected override void OnInitialized()
    {
        _error = false;
        ErrorMessage = string.Empty;
    }

    protected override async Task OnParametersSetAsync()
    {
        if (SelectedLocation != null)
        {
            var query = $"{SelectedLocation.Name},{SelectedLocation.Country}";
            
            try
            {
                _error = false;
                ErrorMessage = string.Empty;   
                if (OpenWeatherMapClient != null) 
                    _weather = await OpenWeatherMapClient.WeatherAsync(query);
            }
            catch (OpenWeatherMapApiException exception)
            {
                _error = true;
                ErrorMessage = "An error occurred, please try again.";
                Log.Error(exception, "{Message}" , exception.Message);
            }
            catch (Exception exception)
            {
                Log.Error(exception, "{Message}" , exception.Message);
                _error = true;
                ErrorMessage = "An error occurred, please try again.";
            }
        }
    }
    
}