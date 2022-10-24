using AccountManager.Models;

namespace AccountManager.DAL;

public interface ICrud
{
    public void Insert(IModel model);
    public IEnumerable<IModel> GetAll();
    public IModel GetById(int id);
    public void Update(IModel model);
    public void Delete(int id);
}