using System.Reactive;
using AccountManager.BL;
using AccountManager.DAL;
using ReactiveUI;

namespace AccountManager.App.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    #region Variables

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

    #endregion

    #region Commands

    public ReactiveCommand<Unit, Unit> ClearCommand { get; }
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }

    #endregion

    #region Constructor

    public MainWindowViewModel()
    {
        ClearCommand = ReactiveCommand.Create(Clear);
        LoginCommand = ReactiveCommand.Create(Login);
    }

    #endregion

    #region Methods

    private void Clear()
    {
        InputLogin = string.Empty;
        InputPassword = string.Empty;
    }

    private void Login()
    {
        var db = new DataContext(new Services(new DataBaseContext()));
        db.LoadData();

        var res = db.Auth(InputLogin, InputPassword);
        Output = res.result ? $"Вы успешно авторизовались. Ваша роль - {res.roleName}" : res.errorMsg;
    }

    #endregion
}
