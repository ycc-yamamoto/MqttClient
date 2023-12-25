using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MqttClient.ViewModels;

public abstract partial class WindowViewModelBase : ViewModelBase
{
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    private double top;

    [ObservableProperty]
    private double left;

    [ObservableProperty]
    private double height;

    [ObservableProperty]
    private double width;

    [ObservableProperty]
    private WindowState windowState;

    protected WindowViewModelBase(
        string title,
        double top,
        double left,
        double height,
        double width,
        WindowState windowState = WindowState.Normal)
    {
        this.Title = title;
        this.Top = top;
        this.Left = left;
        this.Height = height;
        this.Width = width;
        this.WindowState = windowState;
    }

    protected virtual ValueTask OnViewInitializedAsync()
    {
        return default;
    }

    protected virtual ValueTask OnViewLoadedAsync()
    {
        return default;
    }

    protected virtual ValueTask OnViewContentRenderedAsync()
    {
        return default;
    }

    protected virtual ValueTask OnViewClosingAsync()
    {
        return default;
    }

    protected virtual ValueTask OnViewClosedAsync()
    {
        return default;
    }

    [RelayCommand]
    private async Task ViewInitializedAsync()
    {
        await this.OnViewInitializedAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task ViewLoadedAsync()
    {
        await this.OnViewLoadedAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task ViewContentRenderedAsync()
    {
        await this.OnViewContentRenderedAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task ViewClosingAsync()
    {
        await this.OnViewClosingAsync().ConfigureAwait(false);
    }

    [RelayCommand]
    private async Task ViewClosedAsync()
    {
        await this.OnViewClosedAsync().ConfigureAwait(false);
    }
}
