using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.DataProtection;
using Serilog;
using Serilog.Events;
using WeatherApp.Data;

var appName = "weather-app";

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .MinimumLevel.Override("System", LogEventLevel.Warning)
    .Enrich.WithProperty("ApplicationContext", appName)
    .Enrich.FromLogContext()
    .WriteTo.Console(
        outputTemplate:
        "[{Timestamp:yyy-MM-dd HH:mm:ss.fff zzz} {Level}] {Message} ({Scope}) - ({SourceContext:l}){NewLine}{Exception}" + "  " + appName + " ")
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


var keyPath = builder.Configuration["ApplicationSettings:KeyPath"]?? string.Empty;
if (keyPath == null)
{
    Log.Information("Data protection key path has an invalid value '{KeyPath}'", keyPath);
    throw new ArgumentNullException(nameof(keyPath));
}
builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(keyPath));

var openWeatherMapAPIKey = builder.Configuration["ApplicationSettings:OpenWeatherMapAPIKey"]?? string.Empty;


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "weather-app";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
});

var redisConnection = builder.Configuration["ApplicationSettings:Redis"]?? string.Empty;

if (!string.IsNullOrEmpty(redisConnection))
{
    Log.Information("Setting up Redis");
    builder.Services.AddSignalR().AddStackExchangeRedis(redisConnection);
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
