namespace src.DriverRatings.Infrastructure.Commands.Token
{
  public class RevokeRefreshToken : AuthenticateCommandBase
  {
    public string RefreshToken { get; set; }
  }
}