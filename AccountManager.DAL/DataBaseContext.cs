using AccountManager.DAL.Tables;

namespace AccountManager.DAL;

public class DataBaseContext : AbstractBaseContext
{
    public DataBaseContext() : base(new TableRoles(), new TableAccounts(), new TableUsers())
    {
    }
}
