using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services.Interfaces
{
  public interface ITokenManager : IService
  {
    Task<string> CreateRefreshTokenAsync(UserDto userDto);
    Task<JwtDto> RefreshAccessToken(string refreshToken);
    Task RevokeRefreshTokenAsync(string refreshToken);
  }
}