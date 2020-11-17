using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using src.DriverRatings.Server.Infrastructure.Commands.Token;
using src.DriverRatings.Server.Infrastructure.Extensions;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Commands.Handlers.Token
{
  public class RefreshAccessTokenHandler : ICommandHandler<RefreshAccessToken>
  {
    private readonly IMemoryCache _memoryCache;
    private readonly ITokenManager _tokenManager;

    public RefreshAccessTokenHandler(IMemoryCache memoryCache, ITokenManager tokenManager)
      => (_memoryCache, _tokenManager) = (memoryCache, tokenManager);

    public async Task HandleAsync(RefreshAccessToken command)
    {
      var jwt = await this._tokenManager.RefreshAccessToken(command.RefreshToken);
      this._memoryCache.SetJwt(command.CacheId, jwt);
    }
  }
}