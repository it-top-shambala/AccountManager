namespace AccountManager.Models;

public class User : AbstractModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
}