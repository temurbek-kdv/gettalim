﻿namespace GetTalim.Service.Interfaces.Students;

public interface IIdentityService
{
    public long UserId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public string IdentityRole { get; }
}
