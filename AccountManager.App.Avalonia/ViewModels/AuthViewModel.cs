using System.Reactive;
using AccountManager.BL;
using AccountManager.DAL;
using ReactiveUI;

namespace AccountManager.App.Avalonia.ViewModels;

public class AuthViewModel : ViewModelBase
{
    private bool _canExecute;
    public bool CanExecute {
        get { return _canExecute; }
        set { this.RaiseAndSetIfChanged(ref _canExecute, value); }
    }

    private AccountViewModel? _accountViewModel;
    public AccountViewModel? AccountViewModel
    {
        get => _accountViewModel;
        set => this.RaiseAndSetIfChanged(ref _accountViewModel, value);
    }

    private string _login;
    public string InputLogin
    {
        get => _login;
        set => this.RaiseAndSetIfChanged(ref _login, value);
    }

    private string _password;
    public string InputPassword
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value);
    }

    private string _output;
    public string Output
    {
        get => _output;
        set => this.RaiseAndSetIfChanged(ref _output, value);
    }

    public ReactiveCommand<Unit, Unit> ClearCommand { get; }
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }
    public ReactiveCommand<Unit, AccountViewModel?> AuthCommand { get; }

    public AuthViewModel()
    {
        ClearCommand = ReactiveCommand.Create(() =>
        {
            InputLogin = "";
            InputPassword = "";
            Output = "";
        });

        LoginCommand = ReactiveCommand.Create(Login);
        CanExecute = false;
        AuthCommand = ReactiveCommand.Create(() => AccountViewModel, this.WhenAnyValue(f => f.CanExecute));
    }

    private void Login()
    {
        var db = new DataContext(new Services(new DataBaseContext()));
        db.LoadData();

        var result = db.Auth(InputLogin, InputPassword);
        Output = result.result ? $"Вы успешно авторизовались. Ваша роль - {result.roleName}" : result.errorMsg;

        if (result.result)
        {
            AccountViewModel = new AccountViewModel
            {
                AccountId = result.accountId,
                Login = result.login,
                RoleName = result.roleName
            };
            CanExecute = true;
        }
        else
        {
            AccountViewModel = null;
            CanExecute = false;
        }
    }
}
