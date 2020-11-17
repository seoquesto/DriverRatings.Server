namespace src.DriverRatings.Server.Infrastructure.Settings
{
  public class GeneralSettings : ISettings
  {
    public string Name { get; set; }
    public bool SeedData { get; set; }
  }
}