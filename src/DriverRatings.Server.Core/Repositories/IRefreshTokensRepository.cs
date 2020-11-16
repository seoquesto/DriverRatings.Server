using System.Threading.Tasks;
using src.DriverRatings.Server.Core.Models;

namespace src.DriverRatings.Server.Core.Repositories
{
  public interface IRefreshTokensRepository
  {
    Task AddAsync(RefreshToken refreshToken);
    Task<RefreshToken> GetAsync(string token);
    Task UpdateAsync(RefreshToken refreshToken);
  }
}