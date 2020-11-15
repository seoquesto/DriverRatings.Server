using System;

namespace src.DriverRatings.Infrastructure.Commands.Identity
{
  public class Login : ICommand
  {
    // TokenId for ICacheMemory in order to return cached value.
    public Guid CacheId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
  }
}