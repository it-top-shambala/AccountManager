using AccountManager.Models;

namespace AccountManager.BL;

public class DataContext
{
    public IEnumerable<Role> Roles { get; set; }
    public IEnumerable<Account> Accounts { get; set; }
    public IEnumerable<User> Users { get; set; }

    private Services _services;

    public DataContext(Services services)
    {
        _services = services;
    }

    public void LoadData()
    {
        Roles = _services.RolesServices.GetAll();
        Accounts = _services.AccountsServices.GetAll();
        Users = _services.UserServices.GetAll();
    }

    private Account? Login(string login, string password)
    {
        return Accounts.FirstOrDefault(a => a.Login == login && a.Password == password);
    }

    private Role? GetRole(int id)
    {
        return Roles.FirstOrDefault(r => r.RoleId == id);
    }

    public (bool result, string errorMsg, string roleName) Auth(string login, string password)
    {
        var account = Login(login, password);
        if (account is null)
        {
            return (result: false, errorMsg: "Пользователь с такими логином и паролем не найден.", string.Empty);
        }

        var role = GetRole(account.RoleId);
        if (role is null)
        {
            return (result: false, errorMsg: "Непредвиденная ошибка", string.Empty);
        }

        return (result: true, errorMsg: string.Empty, role.Name);
    }
}
