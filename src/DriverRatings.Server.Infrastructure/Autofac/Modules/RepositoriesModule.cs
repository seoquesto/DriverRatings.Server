using System.Reflection;
using Autofac;
using MongoDB.Driver;
using src.DriverRatings.Server.Core.Repositories;
using src.DriverRatings.Server.Infrastructure.Settings;
using Module = Autofac.Module;

namespace src.DriverRatings.Server.Infrastructure.Autofac.Modules
{
  public class RepositoriesModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      var assembly = typeof(RepositoriesModule).GetTypeInfo().Assembly;
      builder.RegisterAssemblyTypes(assembly)
             .Where(x => x.IsAssignableTo<IRepository>())
             .AsImplementedInterfaces()
             .InstancePerLifetimeScope();

      builder.Register((context, parameter) =>
      {
        var mongoSettings = context.Resolve<MongoSettings>();
        return new MongoClient(mongoSettings.ConnectionString);
      }).As<IMongoClient>()
        .SingleInstance();

      builder.Register((context, parameter) =>
      {
        var mongoSettings = context.Resolve<MongoSettings>();
        var mongoClient = context.Resolve<IMongoClient>();
        return mongoClient.GetDatabase(mongoSettings.Database);
      }).As<IMongoDatabase>();

      builder.RegisterAssemblyTypes(assembly)
              .Where(x => x.IsAssignableTo<IMongoRepository>())
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();
    }
  }
}