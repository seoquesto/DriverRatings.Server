using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Users;
using src.DriverRatings.Infrastructure.Extensions;
using src.DriverRatings.Infrastructure.Services;

namespace src.DriverRatings.Infrastructure.Handlers.Users
{
  public class RefreshAccessTokenHandler : ICommandHandler<RefreshAccessToken>
  {
    private readonly IUsersService _usersService;
    private readonly IJwtHandler _jtwHandler;
    private readonly IMemoryCache _memoryCache;
    private readonly ITokenManager _tokenManager;

    public RefreshAccessTokenHandler(IUsersService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache, ITokenManager tokenManager)
    {
      this._usersService = userService;
      this._jtwHandler = jwtHandler;
      this._memoryCache = memoryCache;
      this._tokenManager = tokenManager;
    }

    public async Task HandleAsync(RefreshAccessToken command)
    {
      var jwt = await this._tokenManager.RefreshAccessToken(command.Token);
      this._memoryCache.SetJwt(command.CacheId, jwt);
    }

  }
}