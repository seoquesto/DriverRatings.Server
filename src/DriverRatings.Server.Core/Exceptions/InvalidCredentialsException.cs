namespace src.DriverRatings.Server.Core.Exceptions
{
  public class InvalidCredentialsException : DomainException
  {
    public override string Code { get; } = "invalid_credentials";

    public InvalidCredentialsException() : base("Invalid credentials.")
    {
    }

    public InvalidCredentialsException(string message) : base(message)
    {
    }
  }
}