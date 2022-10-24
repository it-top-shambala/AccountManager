using AccountManager.Models;
using DbConfigLib;
using MySql.Data.MySqlClient;

namespace AccountManager.DAL;

public abstract class AbstractTable : ICrud
{
    protected readonly MySqlConnection Db;
    protected readonly MySqlCommand SqlCommand;

    protected AbstractTable()
    {
        Db = new MySqlConnection(DbConfig.ImportFromJson().ToString());
        SqlCommand = new MySqlCommand() { Connection = Db };
    }

    public abstract void Insert(IModel model);
    public abstract IEnumerable<IModel> GetAll();
    public abstract IModel GetById(int id);
    public abstract void Update(IModel model);
    public abstract void Delete(int id);
}