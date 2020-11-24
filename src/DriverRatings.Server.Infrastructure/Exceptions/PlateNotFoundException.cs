namespace src.DriverRatings.Server.Infrastructure.Exceptions
{
  public class PlateNotFoundException : AppException
  {
    public override string Code { get; } = "plate_not_found";

    public PlateNotFoundException(string identifier, string number) : base($"Pate with identifier: {identifier} and number {number} has not been found.")
    {
    }
  }
}