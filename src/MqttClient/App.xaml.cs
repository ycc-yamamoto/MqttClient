using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using ZLogger;

namespace MqttClient;

public sealed partial class App
{
    private readonly ILogger<App> logger;

    public App(ILogger<App> logger)
    {
        this.logger = logger;
        this.DispatcherUnhandledException += this.OnDispatcherUnhandledException;
        TaskScheduler.UnobservedTaskException += this.OnUnobservedTaskException;
        AppDomain.CurrentDomain.UnhandledException += this.OnUnhandledException;
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        this.logger.ZLogCritical(e.Exception, $"Dispatcher unhandled exception. ({sender})");
        this.DispatcherUnhandledException -= this.OnDispatcherUnhandledException;
    }

    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        this.logger.ZLogCritical(e.Exception, $"Unobserved task exception. ({sender})");
        TaskScheduler.UnobservedTaskException -= this.OnUnobservedTaskException;
    }

    private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        this.logger.ZLogCritical(e.ExceptionObject as Exception, $"Unhandled exception. ({sender})");
        AppDomain.CurrentDomain.UnhandledException -= this.OnUnhandledException;
    }
}

