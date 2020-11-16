namespace src.DriverRatings.Server.Infrastructure.Exceptions
{
  public class UserNotFoundException : AppException
  {
    public override string Code { get; } = "user_not_found";

    public UserNotFoundException(string message) : base(message)
    {
    }
  }
}