using System;

namespace src.DriverRatings.Infrastructure.Commands
{
  public class AuthenticateCommandBase : IAuthenticateCommand
  {
    public Guid UserId { get; set; }
  }
}