using AccountManager.Models;

namespace AccountManager.DAL;

public interface ICrud<T> where T : AbstractModel
{
    public void Insert(T model);
    public IEnumerable<T> GetAll();
    public T GetById(int id);
    public void Update(T model);
    public void Delete(int id);
}