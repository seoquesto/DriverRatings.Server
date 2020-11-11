using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services.Interfaces
{
  public interface ITokenManager : IService
  {
    Task<JwtDto> RefreshAccessToken(string refreshToken);
    Task RevokeRefreshToken(string refreshToken);
    Task<string> GenerateRefreshToken(UserDto userDto);
  }
}