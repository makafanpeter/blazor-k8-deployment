using Microsoft.AspNetCore.Components;
using WeatherApp.Data.Client;

namespace WeatherApp.Shared;

public partial class WeatherDetailTemplate : ComponentBase
{
    [Parameter]
    public required WeatherResponse Weather { get; set; }
}