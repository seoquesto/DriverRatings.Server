using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Services
{
  public class DataInitializer : IDataInitializer
  {
    private readonly IIdentityService _identityService;
    private readonly ILogger<DataInitializer> _logger;

    public DataInitializer(IIdentityService identityService, ILogger<DataInitializer> logger)
    {
      this._identityService = identityService;
      this._logger = logger;
    }

    public async Task SeedAsync()
    {
      this._logger.LogTrace("Initializing data...");

      var tasks = new List<Task>();
      for (int i = 0; i < 3; i++)
      {
        var userId = Guid.NewGuid();
        tasks.Add(this._identityService.RegisterAsync(userId, $"user{i}", $"user{i}@email.com", "password", "user"));
      }

      for (int i = 0; i < 3; i++)
      {
        var adminId = Guid.NewGuid();
        tasks.Add(this._identityService.RegisterAsync(adminId, $"admin{i}", $"admin{i}@email.com", "password", "admin"));
      }

      await Task.WhenAll(tasks);
      this._logger.LogTrace("Data was initialized.");
    }
  }
}