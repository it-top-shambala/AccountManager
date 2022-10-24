﻿namespace AccountManager.Models;

public class User : IModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Tel { get; set; }
}