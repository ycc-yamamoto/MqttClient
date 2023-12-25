using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using MqttClient.Views.Pages;
using Wpf.Ui.Controls;

namespace MqttClient.ViewModels;

public sealed partial class MainViewModel : WindowViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<INavigationViewItem> menuItems = new();

    public MainViewModel()
        : base(
            "MQTT Client",
            100,
            100,
            450,
            600)
    {
        this.menuItems.Add(new NavigationViewItem("設定", SymbolRegular.Settings24, typeof(SettingPage)));
    }
}
