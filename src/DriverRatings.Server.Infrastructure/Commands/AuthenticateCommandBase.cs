using System;

namespace src.DriverRatings.Server.Infrastructure.Commands
{
  public class AuthenticateCommandBase : IAuthenticateCommand
  {
    public Guid UserId { get; set; }
  }
}