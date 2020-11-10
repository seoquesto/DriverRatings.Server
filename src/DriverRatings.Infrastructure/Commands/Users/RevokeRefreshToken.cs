namespace src.DriverRatings.Infrastructure.Commands.Users
{
  public class RevokeRefreshToken : AuthenticateCommandBase
  {
    public string Token { get; set; }
  }
}