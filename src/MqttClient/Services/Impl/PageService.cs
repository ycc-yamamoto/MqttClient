using System;
using System.Windows;
using Wpf.Ui;

namespace MqttClient.Services.Impl;

public sealed class PageService : IPageService
{
    private readonly IServiceProvider serviceProvider;

    public PageService(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public T? GetPage<T>()
        where T : class
    {
        if (!typeof(FrameworkElement).IsAssignableFrom(typeof(T)))
        {
            throw new InvalidOperationException("The page should be a WPF control.");
        }

        return this.serviceProvider.GetRequiredService<T>();
    }

    public FrameworkElement? GetPage(Type pageType)
    {
        if (!typeof(FrameworkElement).IsAssignableFrom(pageType))
        {
            throw new InvalidOperationException("The page should be a WPF control.");
        }

        return this.serviceProvider.GetService(pageType) as FrameworkElement;
    }
}
