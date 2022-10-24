namespace AccountManager.Models;

public class Account : IModel
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public bool IsDelete { get; set; }
    public int RoleId { get; set; }
}