using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services
{
  public interface ITokenManager : IService
  {
    Task<JwtDto> RefreshAccessToken(string token);
    Task RevokeRefreshToken(string token);
    Task<string> GenerateRefreshToken(UserDto userDto);
  }
}