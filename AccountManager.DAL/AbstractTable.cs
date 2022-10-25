using AccountManager.Models;
using DbConfigLib;
using MySql.Data.MySqlClient;

namespace AccountManager.DAL;

public abstract class AbstractTable<T> : ICrud<T> where T : AbstractModel
{
    protected readonly MySqlConnection Db;
    protected readonly MySqlCommand SqlCommand;

    protected AbstractTable()
    {
        Db = new MySqlConnection(DbConfig.ImportFromJson().ToString());
        SqlCommand = new MySqlCommand() { Connection = Db };
    }

    public abstract void Insert(T model);
    public abstract IEnumerable<T> GetAll();
    public abstract T GetById(int id);
    public abstract void Update(T model);
    public abstract void Delete(int id);
}