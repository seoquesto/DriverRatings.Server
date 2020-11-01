using System;

namespace src.DriverRatings.Core.Exceptions
{
  public abstract class BaseApplicationException : Exception
  {
    public string Code { get; }

    public BaseApplicationException()
    {
    }

    public BaseApplicationException(string message, params object[] args) : this(string.Empty, message, args)
    {
    }

    public BaseApplicationException(string code, string message, params object[] args) : this(null, code, message, args)
    {
    }

    public BaseApplicationException(Exception innerException, string message, params object[] args)
    {
    }

    public BaseApplicationException(Exception innerException, string code, string message, params object[] args)
    : base(string.Format(message, args), innerException)
    {
    }
  }
}