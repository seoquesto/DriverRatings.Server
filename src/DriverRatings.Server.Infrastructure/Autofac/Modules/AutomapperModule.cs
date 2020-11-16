using Autofac;
using src.DriverRatings.Server.Infrastructure.AutoMapper;

using Module = Autofac.Module;

namespace src.DriverRatings.Server.Infrastructure.Autofac.Modules
{
  public class AutomapperModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);
      builder.RegisterInstance(AutoMapperConfiguration.Configuration());
    }
  }
}