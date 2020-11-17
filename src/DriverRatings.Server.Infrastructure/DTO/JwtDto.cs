namespace src.DriverRatings.Server.Infrastructure.DTO
{
  public class JwtDto
  {
    public string Token { get; set; }
    public string RefreshToken { get; set; }
    public long Expires { get; set; }
  }
}