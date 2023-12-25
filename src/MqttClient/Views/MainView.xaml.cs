using MqttClient.ViewModels;
using Wpf.Ui;
using Wpf.Ui.Appearance;

namespace MqttClient.Views;

public partial class MainView
{
    private readonly INavigationService navigationService;

    private readonly IPageService pageService;

    public MainView(
        INavigationService navigationService,
        IPageService pageService,
        MainViewModel viewModel)
    {
        this.DataContext = viewModel;
        this.navigationService = navigationService;
        this.pageService = pageService;
        SystemThemeWatcher.Watch(this);
        this.InitializeComponent();
        this.RootNavigationView.SetPageService(this.pageService);
        this.navigationService.SetNavigationControl(this.RootNavigationView);
    }
}

