using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AccountManager.App.Avalonia.ViewModels;
using AccountManager.App.Avalonia.Views;
using AccountManager.App.Avalonia.Views.Auth;
using AuthWindow = AccountManager.App.Avalonia.Views.Auth.AuthWindow;

namespace AccountManager.App.Avalonia;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new AuthWindow { DataContext = new AuthViewModel() };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
