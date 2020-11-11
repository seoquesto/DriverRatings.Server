using System.Threading.Tasks;

namespace src.DriverRatings.Infrastructure.Commands
{
  public interface ICommandDispatcher
  {
    Task DispatchAsync<T>(T command) where T : ICommand;
  }
}