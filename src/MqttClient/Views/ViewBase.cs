using System;
using System.Collections.Generic;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors;
using MqttClient.ViewModels;
using Wpf.Ui.Controls;

namespace MqttClient.Views;

public class ViewBase : FluentWindow
{
    private readonly List<EventTrigger> eventTriggers = new();

    protected ViewBase()
    {
#if false
        if (this.DataContext is WindowViewModelBase viewModel)
        {
            this.AddEventTrigger(nameof(this.Initialized), viewModel.ViewInitializedCommand);
            this.AddEventTrigger(nameof(this.Loaded), viewModel.ViewLoadedCommand);
            this.AddEventTrigger(nameof(this.ContentRendered), viewModel.ViewContentRenderedCommand);
            this.AddEventTrigger(nameof(this.Closing), viewModel.ViewClosingCommand);
            this.AddEventTrigger(nameof(this.Closed), viewModel.ViewClosedCommand);
        }
#endif
    }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);

        foreach (var eventTrigger in this.eventTriggers)
        {
            eventTrigger.Detach();
        }

        if (this.DataContext is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }

    private void AddEventTrigger(string eventName, ICommand command)
    {
        var eventTrigger = new EventTrigger(eventName);
        var action = new InvokeCommandAction
        {
            Command = command,
        };

        eventTrigger.Actions.Add(action);
        this.eventTriggers.Add(eventTrigger);
        eventTrigger.Attach(this);
    }
}
