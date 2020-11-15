using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using src.DriverRatings.Infrastructure.Commands.Users;
using src.DriverRatings.Infrastructure.Extensions;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Commands.Handlers.Users
{
  public class LoginHandler : ICommandHandler<Login>
  {
    private readonly IUsersService _usersService;
    private readonly IJwtHandler _jtwHandler;
    private readonly IMemoryCache _memoryCache;
    private readonly ITokenManager _tokenManager;

    public LoginHandler(IUsersService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache, ITokenManager tokenManager)
    {
      this._usersService = userService;
      this._jtwHandler = jwtHandler;
      this._memoryCache = memoryCache;
      this._tokenManager = tokenManager;
    }

    public async Task HandleAsync(Login command)
    {
      await this._usersService.LoginAsync(command.Username, command.Password);
      var user = await this._usersService.GetByUsernameAsync(command.Username);
      var jwt = this._jtwHandler.CreateToken(user.UserId, "user");
      var token = await this._tokenManager.CreateRefreshTokenAsync(user);
      jwt.RefreshToken = token;
      this._memoryCache.SetJwt(command.CacheId, jwt);
    }
  }
}