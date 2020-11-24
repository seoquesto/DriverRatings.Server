namespace src.DriverRatings.Server.Core.Exceptions
{
  public class InvalidPlateNumberException : DomainException
  {
    public override string Code { get; } = "invalid_plate_number";

    public InvalidPlateNumberException(string number) : base($"Invalid plate number: {number}.")
    {
    }
  }
}