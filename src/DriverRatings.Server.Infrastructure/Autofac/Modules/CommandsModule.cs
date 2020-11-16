using System.Reflection;
using Autofac;
using src.DriverRatings.Server.Infrastructure.Commands;
using Module = Autofac.Module;

namespace src.DriverRatings.Server.Infrastructure.Autofac.Modules
{
  public class CommandsModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      var assembly = typeof(CommandsModule).GetTypeInfo().Assembly;
      builder.RegisterType<CommandDispatcher>()
              .As<ICommandDispatcher>()
              .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assembly)
              .AsClosedTypesOf(typeof(ICommandHandler<,>))
              .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assembly)
              .AsClosedTypesOf(typeof(ICommandHandler<>))
              .InstancePerLifetimeScope();
    }
  }
}