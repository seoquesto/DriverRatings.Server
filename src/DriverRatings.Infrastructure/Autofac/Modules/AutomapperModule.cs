using Autofac;
using src.DriverRatings.Infrastructure.AutoMapper;

using Module = Autofac.Module;

namespace src.DriverRatings.Infrastructure.Autofac.Modules
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