using System;

namespace src.DriverRatings.Infrastructure.Commands.Users
{
  public class RefreshAccessToken : AuthenticateCommandBase
  {
    public Guid CacheId { get; set; }
    public string Token { get; set; }
  }
}