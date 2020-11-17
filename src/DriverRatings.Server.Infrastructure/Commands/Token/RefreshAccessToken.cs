using System;

namespace src.DriverRatings.Server.Infrastructure.Commands.Token
{
  public class RefreshAccessToken : AuthenticateCommandBase
  {
    public Guid CacheId { get; set; }
    public string RefreshToken { get; set; }
  }
}