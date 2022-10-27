using AccountManager.DAL;
using AccountManager.Models;

namespace AccountManager.BL;

public class AccountsServices : ICrud<Account>
{
    private readonly ICrud<Account> _crud;

    public AccountsServices(ICrud<Account> crud)
    {
        _crud = crud;
    }

    public void Insert(Account account)
    {
        _crud.Insert(account);
    }

    public IEnumerable<Account> GetAll()
    {
        return _crud.GetAll();
    }

    public Account GetById(int id)
    {
        return _crud.GetById(id);
    }

    public void Update(Account account)
    {
        _crud.Update(account);
    }

    public void Delete(int id)
    {
        _crud.Delete(id);
    }
}
