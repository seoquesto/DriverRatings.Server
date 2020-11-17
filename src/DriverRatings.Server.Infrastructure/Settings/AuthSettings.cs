namespace src.DriverRatings.Server.Infrastructure.Settings
{
  public class AuthSettings : ISettings
  {
    public string Key { get; set; }
    public string Issuer { get; set; }
    public int ExpiryMinutes { get; set; }
  }
}