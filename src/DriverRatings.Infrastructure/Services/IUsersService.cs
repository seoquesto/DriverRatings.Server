using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services
{
  public interface IUsersService : IService
  {
    Task RegisterAsync(Guid userId, string username, string email, string password);
    Task LoginAsync(string username, string password);
    Task<UserDto> GetByIdAsync(Guid id);
    Task<UserDto> GetByEmailAsync(string email);
    Task<UserDto> GetByUsernameAsync(string username);
  }
}