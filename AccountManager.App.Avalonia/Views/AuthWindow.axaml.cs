using System;
using AccountManager.App.Avalonia.ViewModels;
using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AccountManager.App.Avalonia.Views;

public partial class AuthWindow : ReactiveWindow<AuthViewModel>
{
    public AuthWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif

        this.WhenActivated(d => d(ViewModel!.AuthCommand.Subscribe(Close)));
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}

