using System;

namespace src.DriverRatings.Server.Infrastructure.Commands.Token
{
  // Contract between api and client.
  public class RefreshAccessToken : AuthenticateCommandBase
  {
    public Guid CacheId { get; set; }
    public string RefreshToken { get; set; }
  }
}