namespace src.DriverRatings.Server.Core.Exceptions
{
  public class InvalidPlateIdentifierException : DomainException
  {
    public override string Code { get; } = "invalid_plate_identifier";

    public InvalidPlateIdentifierException(string identifier) : base($"Invalid plate identifier: {identifier}.")
    {
    }
  }
}