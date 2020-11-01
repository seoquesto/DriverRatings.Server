using System.Threading.Tasks;

namespace src.DriverRatings.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}