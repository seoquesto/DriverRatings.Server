using System;
using src.DriverRatings.Core.Models;

namespace src.DriverRatings.Infrastructure.Services
{
  public class ServiceException : BaseApplicationException
  {
    public ServiceException(string code) : base(code)
    {
    }

    public ServiceException(string message, params object[] args) : this(string.Empty, message, args)
    {
    }

    public ServiceException(string code, string message, params object[] args) : this(null, code, message, args)
    {
    }

    public ServiceException(Exception innerException, string message, params object[] args)
    {
    }

    public ServiceException(Exception innerException, string code, string message, params object[] args)
    : base(code, string.Format(message, args), innerException)
    {

    }
  }
}