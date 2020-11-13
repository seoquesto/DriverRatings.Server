namespace src.DriverRatings.Infrastructure.Exceptions
{
     public class UsernameInUseException : AppException
  {
    public override string Code { get; } = "username_in_use";

    public UsernameInUseException(string username) : base($"Username in use: {username}.")
    {
    }
  }
}