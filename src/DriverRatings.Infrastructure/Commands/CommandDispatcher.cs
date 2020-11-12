using System.Threading.Tasks;
using Autofac;

namespace src.DriverRatings.Infrastructure.Commands
{
  public class CommandDispatcher : ICommandDispatcher
  {
    private readonly IComponentContext _componentContext;

    public CommandDispatcher(IComponentContext componentContext)
      => _componentContext = componentContext;

    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
      => await this._componentContext.Resolve<ICommandHandler<TCommand>>().HandleAsync(command);

    public async Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand
      => await this._componentContext.Resolve<ICommandHandler<TCommand, TResult>>().HandleAsync(command);
  }
}