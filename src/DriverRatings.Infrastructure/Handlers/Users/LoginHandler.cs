using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Users;
using src.DriverRatings.Infrastructure.Extensions;
using src.DriverRatings.Infrastructure.Services;

namespace src.DriverRatings.Infrastructure.Handlers.Users
{
  public class LoginHandler : ICommandHandler<Login>
  {
    private readonly IUsersService _usersService;
    private readonly IJwtHandler _jtwHandler;
    private readonly IMemoryCache _memoryCache;

    public LoginHandler(IUsersService userService, IJwtHandler jwtHandler, IMemoryCache memoryCache)
    {
      this._usersService = userService;
      this._jtwHandler = jwtHandler;
      this._memoryCache = memoryCache;

    }
    public async Task HandleAsync(Login command)
    {
      await this._usersService.LoginAsync(command.Email, command.Password);
      var user = await this._usersService.GetByEmailAsync(command.Email);
      var jwt = this._jtwHandler.CreateToken(user.UserId, "user");
      this._memoryCache.SetJwt(command.TokenId, jwt);
    }
  }
}