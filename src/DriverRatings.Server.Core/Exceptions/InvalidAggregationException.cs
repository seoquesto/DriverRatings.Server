namespace src.DriverRatings.Server.Core.Exceptions
{
  public class InvalidAggregationException : DomainException
  {
    public override string Code { get; } = "invalid_id";

    public InvalidAggregationException(string message) : base(message)
    {
    }
  }
}