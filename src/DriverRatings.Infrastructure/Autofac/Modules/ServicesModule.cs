using System.Reflection;
using Autofac;
using src.DriverRatings.Infrastructure.Services;
using Module = Autofac.Module;

namespace src.DriverRatings.Infrastructure.Autofac.Modules
{
  public class ServicesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      var assembly = typeof(ServicesModule).GetTypeInfo().Assembly;
      builder.RegisterType<Encrypter>()
           .As<IEncrypter>()
           .SingleInstance();

      builder.RegisterType<JwtHandler>()
              .As<IJwtHandler>()
              .SingleInstance();

      builder.RegisterAssemblyTypes(assembly)
              .Where(x => x.IsAssignableTo<IService>())
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

      builder.RegisterType<DataInitializer>()
              .As<IDataInitializer>()
              .SingleInstance();
    }
  }
}