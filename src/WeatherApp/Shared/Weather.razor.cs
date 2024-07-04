using Microsoft.AspNetCore.Components;
using Serilog;
using WeatherApp.Data.Client;

namespace WeatherApp.Shared;

public partial class Weather: ComponentBase
{
    
    
    ICollection<GeoResponse>? _geoResponses;
    GeoResponse? _selectedLocation;
    string? _filter;
    private string? _selectedCityName;
    
    
    [Inject]
    private IOpenWeatherMapClient? OpenWeatherMapClient { get; set; }

    private string? ErrorMessage { get; set; }
    
    // Tracking of asynchronous calls.
    private bool _loading;

    private bool _error;
    
    
    protected override void OnInitialized()
    {
        _error = false;
        ErrorMessage = string.Empty;
        _loading = false;
    }
 
    async Task HandleInput(ChangeEventArgs e)
    {
        _filter = e.Value?.ToString();
        if (_filter?.Length > 2)
        {
            if (_loading)
            {
                return;
            }
            try
            {
                    
                if (OpenWeatherMapClient != null) 
                    _geoResponses = await OpenWeatherMapClient.DirectAsync(_filter, 5);
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
            finally
            {
                _loading = false;
            }
        }
        else
        {
            _geoResponses = null;
            _selectedLocation  = null;
        }
    }
 
    void SelectCity(string name)
    {
        _selectedCityName = name;
        _selectedLocation = _geoResponses!.First(c => c.Name.Equals(_selectedCityName));
        _geoResponses = null;
    }
}