using AccountManager.DAL;

namespace AccountManager.BL;

public class Services
{
    public AccountsServices AccountsServices { get; set; }
    public UserServices UserServices { get; set; }
    public RolesServices RolesServices { get; set; }

    public Services(AbstractBaseContext baseContext)
    {
        AccountsServices = new AccountsServices(baseContext.ContextAccounts);
        RolesServices = new RolesServices(baseContext.ContextRoles);
        UserServices = new UserServices(baseContext.ContextUsers);
    }
}
