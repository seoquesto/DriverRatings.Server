using System;
using src.DriverRatings.Server.Infrastructure.Exceptions;

namespace src.DriverRatings.Server.Infrastructure.Extensions
{
  public class UserNotAllowedToDoThatException : AppException
  {
    public override string Code { get; } = "user_not_allowed_to_do_that";

    public UserNotAllowedToDoThatException(Guid userId) : base($"Username with id : {userId.ToString()} is not allowed to do that.")
    {
    }
  }
}