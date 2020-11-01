namespace src.DriverRatings.Infrastructure.Settings
{
  public class MongoSettings : ISettings
  {
    public string ConnectionString { get; set; }
    public string Database { get; set; }
  }
}