using System.Threading.Tasks;
using Autofac;

namespace src.DriverRatings.Infrastructure.Commands
{
  public class CommandDispatcher : ICommandDispatcher
  {
    private readonly IComponentContext componentContext;

    public CommandDispatcher(IComponentContext componentContext)
    {
      this.componentContext = componentContext;
    }

    public async Task DispatchAsync<T>(T command) where T : ICommand
    {
      await this.componentContext.Resolve<ICommandHandler<T>>().HandleAsync(command);
    }
  }
}