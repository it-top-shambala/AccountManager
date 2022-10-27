using AccountManager.Models;

namespace AccountManager.DAL.Tables;

public class TableUsers : AbstractTable<User>
{
    public override void Insert(User model)
    {
    }

    public override IEnumerable<User> GetAll()
    {
        const string SQL = "SELECT user_id, first_name, last_name, email, tel FROM table_users";
        return GetAllEntities(SQL);
    }

    public override User GetById(int id)
    {
        var sql = $"SELECT user_id, first_name, last_name, email, tel FROM table_users WHERE user_id = {id}";
        return GetEntityById(sql);
    }

    public override void Update(User model)
    {
        var sql =
            $"UPDATE table_users SET first_name = {model.FirstName}, last_name = {model.LastName}, email = {model.Email}, tel = {model.Tel} WHERE user_id = {model.UserId}";
        UpdateEntity(sql);
    }

    public override void Delete(int id)
    {
    }
}
