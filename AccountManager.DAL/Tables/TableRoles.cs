using AccountManager.Models;
using Dapper;

namespace AccountManager.DAL.Tables;

public class TableRoles : AbstractTable<Role>
{
    public override void Insert(Role model)
    {
        Db.Open();

        SqlCommand.CommandText = $"INSERT INTO table_roles(name) VALUES ('{model.Name}')";
        SqlCommand.ExecuteNonQuery();
        
        Db.Close();
    }

    public override IEnumerable<Role> GetAll()
    {
        const string SQL = "SELECT role_id, name FROM table_roles";
        return GetAllEntities(SQL);
    }

    public override Role GetById(int id)
    {
        var sql = $"SELECT role_id, name FROM table_roles WHERE role_id = {id}";
        return GetEntityById(sql);
    }

    public override void Update(Role model)
    {
        var sql = $"UPDATE table_roles SET name = {model.Name} WHERE role_id = {model.RoleId}";
        UpdateEntity(sql);
    }

    public override void Delete(int id)
    {
        //Ненужный метод
    }
}