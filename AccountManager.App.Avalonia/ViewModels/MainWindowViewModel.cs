using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace AccountManager.App.Avalonia.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private AccountViewModel? _accountViewModel;
    public AccountViewModel? AccountViewModel
    {
        get => _accountViewModel;
        set => this.RaiseAndSetIfChanged(ref _accountViewModel, value);
    }
    public ReactiveCommand<Unit, Unit> AuthCommand { get; }
    public Interaction<AuthViewModel, AccountViewModel?> AuthShowDialog { get; }

    public MainWindowViewModel()
    {
        AuthShowDialog = new Interaction<AuthViewModel, AccountViewModel?>();

        AuthCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var auth = new AuthViewModel();
            var result = await AuthShowDialog.Handle(auth);

            if (result != null)
            {
                AccountViewModel = result;
            }
        });
    }
}
