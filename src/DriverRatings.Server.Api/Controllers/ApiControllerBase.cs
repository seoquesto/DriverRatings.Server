using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.DriverRatings.Server.Infrastructure.Commands;
using src.DriverRatings.Server.Infrastructure.Queries;

namespace src.DriverRatings.Server.Api.Controllers
{
  public abstract class ApiControllerBase : ControllerBase
  {
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
      Guid.Parse(User.Identity.Name) :
      Guid.Empty;

    protected ApiControllerBase(
      ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
      => (_commandDispatcher, _queryDispatcher) = (commandDispatcher, queryDispatcher);

    protected async Task DispatchCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
      this.HandleCommandUserId(command);
      await this._commandDispatcher.DispatchAsync<TCommand>(command);
    }

    protected async Task<TResult> DispatchCommandAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand
    {
      this.HandleCommandUserId(command);
      return await this._commandDispatcher.DispatchAsync<TCommand, TResult>(command);
    }

    protected async Task<TResult> DispatchQueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>
      => await this._queryDispatcher.QueryAsync<TQuery, TResult>(query);

    private void HandleCommandUserId<TCommand>(TCommand command)
    {
      if (command is AuthenticateCommandBase authenticateCommand)
      {
        authenticateCommand.UserId = this.UserId;
      }
    }
  }
}