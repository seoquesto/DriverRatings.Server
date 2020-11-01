using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.DriverRatings.Infrastructure.Commands;

namespace src.DriverRatings.Api.Controllers
{
  public abstract class ApiControllerBase : ControllerBase
  {
    private readonly ICommandDispatcher commandDispatcher;
    protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
      Guid.Parse(User.Identity.Name) :
      Guid.Empty;

    protected ApiControllerBase(ICommandDispatcher commandDispatcher)
    {
      this.commandDispatcher = commandDispatcher;
    }

    protected async Task DispatchAsync<T>(T command) where T : ICommand
    {
      if (command is AuthenticateCommandBase authenticateCommand)
      {
        authenticateCommand.UserId = this.UserId;
      }
      
      await this.commandDispatcher.DispatchAsync(command);
    }
  }
}