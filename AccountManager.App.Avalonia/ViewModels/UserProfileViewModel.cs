namespace AccountManager.App.Avalonia.ViewModels;

public class UserProfileViewModel : ViewModelBase
{
    public int Id { get; set; }

    public UserProfileViewModel(int accountId)
    {
        Id = accountId;
    }
}
