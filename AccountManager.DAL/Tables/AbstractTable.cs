using AccountManager.Models;
using Dapper;
using DbConfigLib;
using MySql.Data.MySqlClient;

namespace AccountManager.DAL.Tables;

public abstract class AbstractTable<T> : ICrud<T> where T : IModel
{
    protected readonly MySqlConnection Db;
    protected readonly MySqlCommand SqlCommand;

    protected AbstractTable()
    {
        Db = new MySqlConnection(DbConfig.ImportFromJson().ToString());
        SqlCommand = new MySqlCommand() { Connection = Db };
        DefaultTypeMap.MatchNamesWithUnderscores = true;
    }

    public abstract void Insert(T model);
    public abstract IEnumerable<T> GetAll();
    public abstract T GetById(int id);
    public abstract void Update(T model);
    public abstract void Delete(int id);

    protected T GetEntityById(string sql)
    {
        Db.Open();
        
        var entity = Db.QuerySingle<T>(sql);
        
        Db.Close();

        return entity;
    }

    protected IEnumerable<T> GetAllEntities(string sql)
    {
        Db.Open();
        
        var entities = Db.Query<T>(sql);
        
        Db.Close();

        return entities;
    }

    protected void UpdateEntity(string sql)
    {
        Db.Open();
        
        SqlCommand.CommandText = sql;
        SqlCommand.ExecuteNonQuery();
        
        Db.Close();
    }
}