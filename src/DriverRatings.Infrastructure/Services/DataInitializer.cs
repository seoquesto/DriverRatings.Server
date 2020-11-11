using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Services
{
  public class DataInitializer : IDataInitializer
  {
    private readonly IUsersService _usersService;
    private readonly ILogger<DataInitializer> _logger;

    public DataInitializer(IUsersService usersService, ILogger<DataInitializer> logger)
    {
      this._usersService = usersService;
      this._logger = logger;
    }

    public async Task SeedAsync()
    {
      this._logger.LogTrace("Initializing data...");

      var tasks = new List<Task>();
      for (int i = 0; i < 3; i++)
      {
        var userId = Guid.NewGuid();
        tasks.Add(this._usersService.RegisterAsync(userId, $"user{i}", $"user{i}@email.com", "password"));
      }

      for (int i = 0; i < 3; i++)
      {
        var adminId = Guid.NewGuid();
        tasks.Add(this._usersService.RegisterAsync(adminId, $"admin{i}", $"admin{i}@email.com", "password"));
      }

      await Task.WhenAll(tasks);
      this._logger.LogTrace("Data was initialized.");
    }
  }
}