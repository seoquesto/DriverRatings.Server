using System;

namespace src.DriverRatings.Core.Exceptions
{
  public class DomainException : BaseApplicationException
  {
    public DomainException(string code) : base(code)
    {
    }

    public DomainException(string message, params object[] args) : this(string.Empty, message, args)
    {
    }

    public DomainException(string code, string message, params object[] args) : this(null, code, message, args)
    {
    }

    public DomainException(Exception innerException, string message, params object[] args)
    {
    }

    public DomainException(Exception innerException, string code, string message, params object[] args)
    : base(code, string.Format(message, args), innerException)
    {
    }
  }
}