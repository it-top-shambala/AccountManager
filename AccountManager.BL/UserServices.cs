using AccountManager.DAL;
using AccountManager.Models;

namespace AccountManager.BL;

public class UserServices : ICrud<User>
{
    private readonly ICrud<User> _crud;

    public UserServices(ICrud<User> crud)
    {
        _crud = crud;
    }

    public void Insert(User model)
    {
        _crud.Insert(model);
    }

    public IEnumerable<User> GetAll()
    {
        return _crud.GetAll();
    }

    public User GetById(int id)
    {
        return _crud.GetById(id);
    }

    public void Update(User model)
    {
        _crud.Update(model);
    }

    public void Delete(int id)
    {
        _crud.Delete(id);
    }
}