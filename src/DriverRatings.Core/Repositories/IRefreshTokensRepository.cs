using System.Threading.Tasks;
using src.DriverRatings.Core.Models;

namespace src.DriverRatings.Core.Repositories
{
  public interface IRefreshTokensRepository
  {
    Task AddAsync(RefreshToken refreshToken);
    Task<RefreshToken> GetAsync(string token);
    Task UpdateAsync(RefreshToken refreshToken);
  }
}