using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services.Interfaces
{
  public interface IUsersService : IService
  {
    Task<UserDto> GetByIdAsync(Guid userId);
    Task<UserDto> GetByEmailAsync(string email);
    Task<UserDto> GetByUsernameAsync(string username);
  }
}