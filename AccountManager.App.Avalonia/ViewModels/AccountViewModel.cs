using AccountManager.Models;
using ReactiveUI;

namespace AccountManager.App.Avalonia.ViewModels;

public class AccountViewModel : ViewModelBase
{
    private int _id;
    public int AccountId
    {
        get => _id;
        set => this.RaiseAndSetIfChanged(ref _id, value);
    }

    private string _login;
    public string Login
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }

    private string _role;
    public string RoleName
    {
        get => _role;
        set => this.RaiseAndSetIfChanged(ref _role, value);
    }


}
