using System;

namespace src.DriverRatings.Server.Infrastructure.Exceptions
{
  public abstract class AppException : ApplicationException
  {
    public virtual string Code { get; }

    protected AppException(string code) : base(code)
    {
    }
  }
}