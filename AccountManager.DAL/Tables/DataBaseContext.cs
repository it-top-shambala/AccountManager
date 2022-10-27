namespace AccountManager.DAL.Tables;

public class DataBaseContext : AbstractBaseContext
{
    public DataBaseContext() : base(new TableRoles(), new TableAccounts(), new TableUsers())
    {
    }
}
