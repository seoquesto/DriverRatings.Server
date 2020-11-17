using Autofac;
using Microsoft.Extensions.Configuration;
using src.DriverRatings.Server.Infrastructure.Extensions;
using src.DriverRatings.Server.Infrastructure.Settings;

using Module = Autofac.Module;

namespace src.DriverRatings.Server.Infrastructure.Autofac.Modules
{
  public class SettingsModule : Module
  {
    private readonly IConfiguration _configuration;

    public SettingsModule(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()).SingleInstance();
      builder.RegisterInstance(_configuration.GetSettings<AuthSettings>()).SingleInstance();
      builder.RegisterInstance(_configuration.GetSettings<MongoSettings>()).SingleInstance();
    }
  }
}