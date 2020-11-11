using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Handlers;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Services
{
  internal class HandlerTaskRunner : IHandlerTaskRunner
  {
    private readonly Handler _handler;
    private readonly Func<Task> _validate;
    private readonly ISet<IHandlerTask> _handlerTasks;

    public HandlerTaskRunner(Handler handler, Func<Task> validate, ISet<IHandlerTask> handlerTasks)
    {
      this._handler = handler;
      this._validate = validate;
      this._handlerTasks = handlerTasks;
    }

    public IHandlerTask Run(Func<Task> run)
    {
      var handlerTask = new HandlerTask(this._handler, run);
      this._handlerTasks.Add(handlerTask);

      return handlerTask;
    }
  }
}