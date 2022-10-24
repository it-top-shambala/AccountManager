using AccountManager.Models;
using Dapper;

namespace AccountManager.DAL;

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
        Db.Open();

        const string SQL = "SELECT role_id, name FROM table_roles";
        var roles = Db.Query<Role>(SQL);
        
        Db.Close();

        return roles;
    }

    public override Role GetById(int id)
    {
        Db.Open();

        var sql = $"SELECT role_id, name FROM table_roles WHERE role_id = {id}";
        var role = Db.QuerySingle<Role>(sql);
        
        Db.Close();

        return role;
    }

    public override void Update(Role model)
    {
        Db.Open();
        
        SqlCommand.CommandText = $"UPDATE table_roles SET name = {model.Name} WHERE role_id = {model.Id}";
        SqlCommand.ExecuteNonQuery();
        
        Db.Close();
    }

    public override void Delete(int id)
    {
        //Ненужный метод
    }
}