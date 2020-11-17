using System.Threading.Tasks;

namespace src.DriverRatings.Server.Infrastructure.Commands
{
  public interface ICommandDispatcher
  {
    Task DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
    Task<TResult> DispatchAsync<TCommand, TResult>(TCommand command) where TCommand : ICommand;
  }
}