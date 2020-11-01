using Autofac;
using Microsoft.Extensions.Configuration;
using src.DriverRatings.Infrastructure.Autofac.Modules;
using Module = Autofac.Module;

namespace src.DriverRatings.Infrastructure.Autofac
{
  public class AutofacModules : Module
  {
    private readonly IConfiguration _configuration;

    public AutofacModules(IConfiguration configuration)
    {
      this._configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      builder.RegisterModule(new SettingsModule(this._configuration));
      builder.RegisterModule<AutomapperModule>();
      builder.RegisterModule<RepositoriesModule>();
      builder.RegisterModule<ServicesModule>();
      builder.RegisterModule<AutomapperModule>();
      builder.RegisterModule<CommandsModule>();
    }
  }
}