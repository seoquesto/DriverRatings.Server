using System.Threading.Tasks;

namespace src.DriverRatings.Server.Infrastructure.Commands
{
  public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
  {
    Task<TResult> HandleAsync(TCommand command);
  }
  public interface ICommandHandler<in TCommand> where TCommand : ICommand
  {
    Task HandleAsync(TCommand command);
  }
}