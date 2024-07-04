namespace WeatherApp.Data;

public class ApiKeyDelegatingHandler:  DelegatingHandler
{
    private readonly string _apiKey;
    public ApiKeyDelegatingHandler(string apiKey)
    {
        _apiKey = apiKey;
    }
    
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Append the API key as a query parameter
        if (request.RequestUri != null)
        {
            var uriBuilder = new UriBuilder(request.RequestUri);
            var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
            query["appid"] = _apiKey;
            uriBuilder.Query = query.ToString();
            request.RequestUri = uriBuilder.Uri;
        }
        return await base.SendAsync(request, cancellationToken);
    }
}