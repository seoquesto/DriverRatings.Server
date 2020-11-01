using System;
using System.Threading.Tasks;
using src.DriverRatings.Core.Exceptions;
using src.DriverRatings.Infrastructure.Handlers;

namespace src.DriverRatings.Infrastructure.Services
{
  public class HandlerTask : IHandlerTask
  {
    private readonly IHandler _handler;
    private readonly Func<Task> _run;
    private Func<Task> _validate;
    private Func<Task> _always;
    private Func<Task> _onSuccess;
    private Func<BaseApplicationException, Task> _onCustomException;
    private Func<Exception, Task> _onError;
    private bool _propagateException = true;
    private bool _executeOnError = true;


    public HandlerTask(IHandler handler, Func<Task> run)
    {
      this._handler = handler;
      this._run = run;
    }

    public HandlerTask(IHandler handler, Func<Task> run, Func<Task> validate)
    {
      this._handler = handler;
      this._run = run;
      this._validate = validate;
    }

    public IHandlerTask Always(Func<Task> always)
    {
      this._always = always;
      return this;
    }

    public IHandlerTask DoNotPropagateException()
    {
      this._propagateException = false;
      return this;
    }

    public async Task ExecuteAsync()
    {
      try
      {
        if (this._validate != null)
        {
          await this._validate();
        }
        if (this._run != null)
        {
          await this._run();
        }
        if (this._onSuccess != null)
        {
          await this._onSuccess();
        }
      }
      catch (Exception ex)
      {
        await this.HandleExceptionAsync(ex);
        if (this._propagateException)
        {
          throw;
        }
      }
      finally
      {
        if (this._always != null)
        {
          await this._always();
        }
      }
    }

    private async Task HandleExceptionAsync(Exception ex)
    {
      var customException = ex as BaseApplicationException;

      if (customException != null)
      {
        if (this._onCustomException != null)
        {
          await this._onCustomException(customException);
        }
      }

      if (customException == null)
      {
        var exception = ex as Exception;
        if (this._onError != null && exception != null)
        {
          await this._onError(exception);
        }
      }
    }

    public IHandler Next()
    {
      return this._handler;
    }

    public IHandlerTask OnCustomError(Func<BaseApplicationException, Task> onCustomException, bool propagateException = false, bool executeOnError = false)
    {
      this._onCustomException = onCustomException;
      this._propagateException = propagateException;
      this._executeOnError = executeOnError;
      return this;
    }

    public IHandlerTask OnError(Func<Exception, Task> onError, bool propagateException = false, bool executeOnError = false)
    {
      this._onError = onError;
      this._propagateException = propagateException;
      this._executeOnError = executeOnError;
      return this;
    }

    public IHandlerTask OnSuccess(Func<Task> onSuccess)
    {
      this._onSuccess = onSuccess;
      return this;
    }

    public IHandlerTask PropagateException()
    {
      this._propagateException = true;
      return this;
    }
  }
}