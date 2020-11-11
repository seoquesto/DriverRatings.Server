using System.Threading.Tasks;
using Autofac;

namespace src.DriverRatings.Infrastructure.Commands
{
  public class CommandDispatcher : ICommandDispatcher
  {
    private readonly IComponentContext _componentContext;

    public CommandDispatcher(IComponentContext componentContext)
      => _componentContext = componentContext;

    public async Task DispatchAsync<T>(T command) where T : ICommand
      => await this._componentContext.Resolve<ICommandHandler<T>>().HandleAsync(command);
  }
}