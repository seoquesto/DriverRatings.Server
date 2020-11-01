using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Handlers;

namespace src.DriverRatings.Infrastructure.Services
{
  public interface IHandlerTaskRunner
  {
    IHandlerTask Run(Func<Task> run);
  }
}