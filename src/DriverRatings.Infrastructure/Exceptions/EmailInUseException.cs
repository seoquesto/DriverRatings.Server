namespace src.DriverRatings.Infrastructure.Exceptions
{
     public class EmailInUseException : AppException
  {
    public override string Code { get; } = "email_in_use";

    public EmailInUseException(string email) : base($"Email in use: {email}.")
    {
    }
  }
}