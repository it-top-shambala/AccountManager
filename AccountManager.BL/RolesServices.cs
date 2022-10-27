using AccountManager.DAL;
using AccountManager.Models;

namespace AccountManager.BL;

public class RolesServices : ICrud<Role>
{
    private readonly ICrud<Role> _crud;

    public RolesServices(ICrud<Role> crud)
    {
        _crud = crud;
    }

    public void Insert(Role role)
    {
        _crud.Insert(role);
    }

    public IEnumerable<Role> GetAll()
    {
        return _crud.GetAll();
    }

    public Role GetById(int id)
    {
        return _crud.GetById(id);
    }

    public void Update(Role role)
    {
        _crud.Update(role);
    }

    public void Delete(int id)
    {
        _crud.Delete(id);
    }
}
