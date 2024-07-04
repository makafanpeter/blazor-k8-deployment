namespace WeatherApp.Data.Client;

[System.CodeDom.Compiler.GeneratedCode("NSwag", "14.0.8.0 (NJsonSchema v11.0.1.0 (Newtonsoft.Json v13.0.0.0))")]
public partial interface  IOpenWeatherMapClient
{
    /// <summary>
    /// Get weather data by city name
    /// </summary>
    /// <param name="q">City name and country code (ISO 3166) separated by a comma.</param>
    /// <returns>Weather data retrieved successfully</returns>
    /// <exception cref="OpenWeatherMapApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<WeatherResponse> WeatherAsync(string q);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Get weather data by city name
    /// </summary>
    /// <param name="q">City name and country code (ISO 3166) separated by a comma.</param>
    /// <returns>Weather data retrieved successfully</returns>
    /// <exception cref="OpenWeatherMapApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<WeatherResponse> WeatherAsync(string q, System.Threading.CancellationToken cancellationToken);

    /// <summary>
    /// Get geocoding data by partial city name
    /// </summary>
    /// <param name="q">Partial city name.</param>
    /// <param name="limit">Number of results to return (default is 5).</param>
    /// <returns>Geocoding data retrieved successfully</returns>
    /// <exception cref="OpenWeatherMapApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<GeoResponse>> DirectAsync(string q, int? limit);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <summary>
    /// Get geocoding data by partial city name
    /// </summary>
    /// <param name="q">Partial city name.</param>
    /// <param name="limit">Number of results to return (default is 5).</param>
    /// <returns>Geocoding data retrieved successfully</returns>
    /// <exception cref="OpenWeatherMapApiException">A server side error occurred.</exception>
    System.Threading.Tasks.Task<System.Collections.Generic.ICollection<GeoResponse>> DirectAsync(string q, int? limit, System.Threading.CancellationToken cancellationToken);

}