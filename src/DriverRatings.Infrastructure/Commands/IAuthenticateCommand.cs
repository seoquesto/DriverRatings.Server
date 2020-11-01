
using System;

namespace src.DriverRatings.Infrastructure.Commands
{
  public interface IAuthenticateCommand : ICommand
  {
    Guid UserId { get; set; }
  }
}