using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using src.DriverRatings.Infrastructure.Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using src.DriverRatings.Infrastructure.Settings;
using System.Text;
using src.DriverRatings.Infrastructure.Extensions;
using Autofac.Extensions.DependencyInjection;
using src.DriverRatings.Api.Middleware;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using src.DriverRatings.Infrastructure.Mongo;
using System;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace DriverRatings.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
    {
      Configuration = configuration;
      Console.WriteLine("Application name: " + webHostEnvironment.ApplicationName);
      Console.WriteLine("Environment name: " + webHostEnvironment.EnvironmentName);
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddOptions();
      services.AddMemoryCache();
      services.AddLogging(loggingBuilder =>
      {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddNLog();
      });

      var authSettings = this.Configuration.GetSettings<AuthSettings>();
      var generalSettings = this.Configuration.GetSettings<GeneralSettings>();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
              .AddJwtBearer(options =>
              {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                  ValidIssuer = authSettings.Issuer,
                  ValidateAudience = false,
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSettings.Key)),
                };
              });
    }

    // ConfigureContainer is where you can register things directly
    // with Autofac. This runs after ConfigureServices so the things
    // here will override registrations made in ConfigureServices.
    // Don't build the container; that gets done for you by the factory.
    public void ConfigureContainer(ContainerBuilder builder)
    {
      // Register your own things directly with Autofac here. Don't
      // call builder.Populate(), that happens in AutofacServiceProviderFactory
      // for you.
      builder.RegisterModule(new AutofacModules(this.Configuration));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      // DATA INITIALIZER (ONLY FOR TESTING AND DEVELOPMENT PURPOSE)
      if (Configuration.GetSettings<GeneralSettings>().SeedData)
      {
        var autofacRoot = app.ApplicationServices.GetAutofacRoot();
        var dataInitializer = autofacRoot.Resolve<IDataInitializer>();
        dataInitializer.SeedAsync();
      }

      MongoConfigurator.Initialize();
      // app.UseHttpsRedirection();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseExceptionMiddleware();
      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
