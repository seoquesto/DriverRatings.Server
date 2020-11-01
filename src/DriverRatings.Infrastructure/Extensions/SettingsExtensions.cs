using Microsoft.Extensions.Configuration;
using src.DriverRatings.Infrastructure.Settings;

namespace src.DriverRatings.Infrastructure.Extensions
{
  public static class SettingsExtensions
  {
    public static T GetSettings<T>(this IConfiguration configuration) where T : class, ISettings, new()
    {
      var settings = new T();
      configuration.GetSection(typeof(T).Name.Replace("Settings", string.Empty)).Bind(settings);
      return settings;
    }
  }
}