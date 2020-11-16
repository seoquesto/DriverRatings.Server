using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Services.Interfaces
{
  public interface ITokenManager : IService
  {
    Task<string> CreateRefreshTokenAsync(UserDto userDto);
    Task<JwtDto> RefreshAccessToken(string refreshToken);
    Task RevokeRefreshTokenAsync(string refreshToken);
  }
}