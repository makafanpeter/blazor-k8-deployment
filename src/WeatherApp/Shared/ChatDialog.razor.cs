using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;
using WeatherApp.Data.Client;


namespace WeatherApp.Shared;

public partial class ChatDialog : ComponentBase, IAsyncDisposable
{
    private HubConnection? _hubConnection;
    private WeatherMessage _message = new();
    [Parameter]
    public Guid? Username { get; set; }

    private string? MessageInput { get; set; }

    [Inject] 
    private NavigationManager? Navigation { get; set; }

    private bool IsConnected => _hubConnection?.State == HubConnectionState.Connected;
    
    protected override async Task OnInitializedAsync()
    {
        var url = Navigation?.ToAbsoluteUri("/weatherHub");
        _hubConnection = new HubConnectionBuilder()
            .WithUrl(url)
            .Build();

        _hubConnection.On<string, WeatherResponse?>("ReceiveMessage", (user, message) =>
        {
            var newMessage = new WeatherMessage
            {
                User = user,
                WeatherResponse = message
            };
            _message = newMessage;
            InvokeAsync(() =>
            {
                StateHasChanged();
                ScrollToBottom();
            });
        });

        await _hubConnection.StartAsync();
    }
    protected override Task OnParametersSetAsync()
    {
        _message.Text = string.Empty;
        return Task.CompletedTask;
    }
    
    private async Task HandleKeyDown(KeyboardEventArgs e)
    {
        if (e.Key == "Enter" && IsConnected)
        {
            await Send();
        }
    }
    
    private async Task Send()
    {
        if (_hubConnection is not null && !string.IsNullOrEmpty(MessageInput))
        {
            await _hubConnection.SendAsync("SendMessage", Username, MessageInput);
            MessageInput = string.Empty;
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_hubConnection != null) await _hubConnection.DisposeAsync();
    }
    
    
    private void ScrollToBottom()
    {
    }
    
    private class WeatherMessage
    {
        public string User { get; set; } = string.Empty;
        public string Text { get; set; } = "An error occurred, please try again.";
        public WeatherResponse? WeatherResponse { get; set; }
    }
}