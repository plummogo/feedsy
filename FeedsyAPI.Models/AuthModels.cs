using Microsoft.AspNetCore.Identity;

namespace FeedsyAPI.Models;

public class RegisterRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}

public class User: IdentityUser
{
    public string FullName { get; set; }
    public string Address { get; set; }
    public DateTime BirthDate { get; set; }
}