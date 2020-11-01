using System.Reflection;
using Autofac;
using src.DriverRatings.Infrastructure.AutoMapper;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Repositories;
using src.DriverRatings.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using src.DriverRatings.Infrastructure.Settings;
using src.DriverRatings.Infrastructure.Extensions;
using System.Linq;

using Module = Autofac.Module;
using System.Collections.Generic;
using System;
using MongoDB.Driver;

namespace src.DriverRatings.Infrastructure.Autofac
{
  public class AppModule : Module
  {
    private readonly IConfiguration _configuration;

    public AppModule(IConfiguration configuration)
    {
      this._configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>()).SingleInstance();
      builder.RegisterInstance(_configuration.GetSettings<AuthSettings>()).SingleInstance();
      builder.RegisterInstance(_configuration.GetSettings<MongoSettings>()).SingleInstance();


      var assembly = typeof(AppModule).GetTypeInfo().Assembly;

      builder.RegisterInstance(AutoMapperConfiguration.Configuration());

      builder.RegisterType<DataInitializer>()
              .As<IDataInitializer>()
              .SingleInstance();

      builder.RegisterType<Encrypter>()
              .As<IEncrypter>()
              .SingleInstance();

      builder.RegisterType<JwtHandler>()
              .As<IJwtHandler>()
              .SingleInstance();

      builder.RegisterAssemblyTypes(assembly)
              .Where(x => x.IsAssignableTo<IRepository>())
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assembly)
              .Where(x => x.IsAssignableTo<IService>())
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

      builder.RegisterType<CommandDispatcher>()
              .As<ICommandDispatcher>()
              .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assembly)
              .AsClosedTypesOf(typeof(ICommandHandler<>))
              .InstancePerLifetimeScope();

      builder.RegisterAssemblyTypes(assembly)
              .Where(x => x.IsAssignableTo<IService>())
              .AsImplementedInterfaces()
              .InstancePerLifetimeScope();

      builder.Register((context, parameter) =>
      {
        var mongoSettings = context.Resolve<MongoSettings>();
        return new MongoClient(mongoSettings.ConnectionString);
      }).As<IMongoClient>().SingleInstance();

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