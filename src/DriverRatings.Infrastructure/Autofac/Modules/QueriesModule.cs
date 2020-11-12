using System.Reflection;
using Autofac;
using src.DriverRatings.Infrastructure.Queries;
using Module = Autofac.Module;

namespace src.DriverRatings.Infrastructure.Autofac.Modules
{
  public class QueriesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      var assembly = typeof(QueriesModule).GetTypeInfo().Assembly;

      builder.RegisterType<QueryDispatcher>()
              .As<IQueryDispatcher>()
              .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assembly)
              .AsClosedTypesOf(typeof(IQueryHandler<,>))
              .InstancePerLifetimeScope();
    }
  }
}