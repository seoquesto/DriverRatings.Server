
using System;

namespace src.DriverRatings.Server.Infrastructure.Commands
{
  public interface IAuthenticateCommand : ICommand
  {
    Guid UserId { get; set; }
  }
}