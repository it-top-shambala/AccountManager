using AccountManager.Models;
using Dapper;

namespace AccountManager.DAL;

public class TableRoles : AbstractTable
{
    public override void Insert(IModel model)
    {
        //TODO
    }

    public override IEnumerable<IModel> GetAll()
    {
        Db.Open();

        const string SQL = "SELECT role_id, name FROM table_roles";
        var roles = Db.Query<Role>(SQL);
        
        Db.Close();

        return roles;
    }

    public override IModel GetById(int id)
    {
        Db.Open();

        var sql = $"SELECT role_id, name FROM table_roles WHERE role_id = {id}";
        var role = Db.QuerySingle<Role>(sql);
        
        Db.Close();

        return role;
    }

    public override void Update(IModel model)
    {
        var name = (model as Role).Name;
        var id = (model as Role).Id;
        Db.Open();
        
        SqlCommand.CommandText = $"UPDATE table_roles SET name = {name} WHERE role_id = {id}";
        SqlCommand.ExecuteNonQuery();
        
        Db.Close();
    }

    public override void Delete(int id)
    {
        //Ненужный метод
    }
}