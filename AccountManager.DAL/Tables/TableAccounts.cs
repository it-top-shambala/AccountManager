using AccountManager.Models;
using Dapper;

namespace AccountManager.DAL.Tables;

public class TableAccounts : AbstractTable<Account>
{
    public override void Insert(Account model)
    {
    }

    public override IEnumerable<Account> GetAll()
    {
        const string SQL = "SELECT account_id, login, password, is_delete, role_id FROM table_accounts";
        return GetAllEntities(SQL);
    }

    public override Account GetById(int id)
    {
        var sql = $"SELECT account_id, login, password, is_delete, role_id FROM table_accounts WHERE account_id = {id}";
        return GetEntityById(sql);
    }

    public override void Update(Account model)
    {
        var sql =
            $"UPDATE table_accounts SET login = {model.Login}, password = {model.Password}, is_delete = {model.IsDelete}, role_id = {model.RoleId} WHERE account_id = {model.AccountId}";
        UpdateEntity(sql);
    }

    public override void Delete(int id)
    {
        var sql = $"UPDATE table_accounts SET is_delete = true WHERE account_id = {id}";
        UpdateEntity(sql);
    }
}
