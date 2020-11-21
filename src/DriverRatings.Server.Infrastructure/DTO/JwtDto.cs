namespace src.DriverRatings.Server.Infrastructure.DTO
{
  // Contract between api and client.
  public class JwtDto
  {
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public long Expires { get; set; }
  }
}