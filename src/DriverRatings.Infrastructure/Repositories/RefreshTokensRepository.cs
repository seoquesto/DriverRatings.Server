using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;

namespace src.DriverRatings.Infrastructure.Repositories
{
  public class RefreshTokensRepository : IRefreshTokensRepository, IMongoRepository
  {
    private const string CollectionName = "refresh_tokens";
    private readonly IMongoCollection<RefreshToken> _refrestTokens;

    public RefreshTokensRepository(IMongoDatabase mongoDatabase)
    {
      this._refrestTokens = mongoDatabase.GetCollection<RefreshToken>(CollectionName);
    }

    public async Task AddAsync(RefreshToken refreshToken)
      => await this._refrestTokens.InsertOneAsync(refreshToken);

    public async Task<RefreshToken> GetAsync(string token)
      => await this._refrestTokens.AsQueryable().FirstOrDefaultAsync(x => x.Token == token);

    public async Task UpdateAsync(RefreshToken refreshToken)
      => await this._refrestTokens.ReplaceOneAsync(x => x.Token == refreshToken.Token, refreshToken);
  }
}