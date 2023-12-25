using Microsoft.Extensions.DependencyInjection.Extensions;
using MqttClient;
using MqttClient.Services.Impl;
using MqttClient.ViewModels;
using MqttClient.Views;
using MqttClient.Views.Pages;
using Utf8StringInterpolation;
using Wpf.Ui;
using ZLogger;
using ZLogger.Providers;

var builder = WpfApplication<App, MainView>.CreateBuilder(args);

builder.Services.AddSingleton<INavigationService, NavigationService>();
builder.Services.AddSingleton<IThemeService, ThemeService>();
builder.Services.AddSingleton<IPageService, PageService>();
builder.Services.TryAddTransient<MainViewModel>();
builder.Services.TryAddTransient<SettingPage>();
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.SetMinimumLevel(LogLevel.Information);
    logging.AddZLoggerRollingFile(options =>
    {
        options.RollingInterval = RollingInterval.Day;
        options.FilePathSelector = (dateTimeOffset, number) =>
            $"logs/{dateTimeOffset.ToLocalTime():yyyy-MM-dd}_{number:000}.log";
        options.RollingSizeKB = 1024;
        options.UsePlainTextFormatter(formatter =>
        {
            formatter.SetPrefixFormatter($"[{0}] {1}",
                (template, info) => template.Format(info.Timestamp.Local, info.LogLevel));
            formatter.SetExceptionFormatter((writer, exception) => Utf8String.Format(writer, $"{exception.Message}"));
        });
    });
});

var app = builder.Build();

await app.RunAsync().ConfigureAwait(false);
return 0;
