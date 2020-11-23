using src.DriverRatings.Server.Core.Exceptions;

namespace src.DriverRatings.Server.Core.Models
{
  public class Plate : PlateIdentifier
  {
    public string Number { get; protected set; }

    protected Plate()
    {
    }

    public Plate(string identifier, string number) : base(identifier)
    {
      string fixedNumber = number?.Trim().ToUpperInvariant();
      if (string.IsNullOrEmpty(fixedNumber))
      {
        throw new InvalidAggregationException("Plate number cannot be empty.");
      }

      if (this.Number == fixedNumber)
      {
        return;
      }

      this.Number = fixedNumber;
    }
  }
}


