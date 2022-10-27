using AccountManager.Models;

namespace AccountManager.DAL;

public abstract class AbstractBaseContext
{
    public ICrud<Role> ContextRoles { get; set; }
    public ICrud<Account> ContextAccounts { get; set; }
    public ICrud<User> ContextUsers { get; set; }

    protected AbstractBaseContext(ICrud<Role> contextRoles, ICrud<Account> contextAccounts, ICrud<User> contextUsers)
    {
        ContextRoles = contextRoles;
        ContextAccounts = contextAccounts;
        ContextUsers = contextUsers;
    }
}
