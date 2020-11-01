using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Handlers;

namespace src.DriverRatings.Infrastructure.Services
{
    public interface IHandler : IService
    {
        IHandlerTask Run(Func<Task> run);
        IHandlerTaskRunner Validate(Func<Task> validate);
        Task ExecuteAllAsync();
    }
}