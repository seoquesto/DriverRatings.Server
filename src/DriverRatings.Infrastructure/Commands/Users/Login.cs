using System;

namespace src.DriverRatings.Infrastructure.Commands.Users
{
  public class Login : ICommand
  {
    // TokenId for ICacheMemory in order to return cached value.
    public Guid TokenId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}