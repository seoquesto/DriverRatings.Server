using System;
using src.DriverRatings.Infrastructure.Exceptions;

namespace src.DriverRatings.Infrastructure.Extensions
{
  public class UserNotAllowedToDoThatException : AppException
  {
    public override string Code { get; } = "user_not_allowed_to_do_that";

    public UserNotAllowedToDoThatException(Guid userId) : base($"Username with id : {userId.ToString()} is not allowed to do that.")
    {
    }
  }
}