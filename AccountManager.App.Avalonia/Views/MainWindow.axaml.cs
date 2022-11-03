using System.Threading.Tasks;
using AccountManager.App.Avalonia.ViewModels;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;

namespace AccountManager.App.Avalonia.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WhenActivated(d => d(ViewModel!.AuthShowDialog.RegisterHandler(DoShowDialogAsync)));
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private async Task DoShowDialogAsync(InteractionContext<AuthViewModel, AccountViewModel?> interaction)
        {
            var dialog = new AuthWindow();
            dialog.DataContext = interaction.Input;

            var result = await dialog.ShowDialog<AccountViewModel?>(this);
            interaction.SetOutput(result);
        }
    }
}
