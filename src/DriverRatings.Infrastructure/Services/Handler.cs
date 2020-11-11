using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Handlers;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Services
{
  public class Handler : IHandler
  {
    private readonly ISet<IHandlerTask> _handlerTasks = new HashSet<IHandlerTask>();

    public IHandlerTaskRunner Validate(Func<Task> validate)
    {
      return new HandlerTaskRunner(this, validate, this._handlerTasks);
    }

    public IHandlerTask Run(Func<Task> run)
    {
      var handlerTask = new HandlerTask(this, run);
      this._handlerTasks.Add(handlerTask);

      return handlerTask;
    }

    public async Task ExecuteAllAsync()
    {
      foreach (var task in this._handlerTasks)
      {
        await task.ExecuteAsync();
      }
      this._handlerTasks.Clear();
    }
  }
}