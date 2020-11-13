namespace src.DriverRatings.Core.Exceptions
{
  public class InvalidIdException : DomainException
  {
    public override string Code { get; } = "invalid_id";

    public InvalidIdException(string message) : base(message)
    {

    }
  }
}