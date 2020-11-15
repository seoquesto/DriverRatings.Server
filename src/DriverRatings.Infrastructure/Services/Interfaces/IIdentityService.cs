using System;
using System.Threading.Tasks;

namespace src.DriverRatings.Infrastructure.Services.Interfaces
{
  public interface IIdentityService : IService
  {
    Task RegisterAsync(Guid userId, string username, string email, string password, string role);
    Task LoginAsync(string username, string password);
  }
}