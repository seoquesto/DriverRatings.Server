using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Queries;

namespace src.DriverRatings.Api.Controllers
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

    protected async Task DispatchCommandAsync<T>(T command) where T : ICommand
    {
      if (command is AuthenticateCommandBase authenticateCommand)
      {
        authenticateCommand.UserId = this.UserId;
      }
      
      await this._commandDispatcher.DispatchAsync(command);
    }
    
    protected async Task<TResult> DispatchQueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>
      => await this._queryDispatcher.QueryAsync<TQuery, TResult>(query);
  }
}