using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Users;
using src.DriverRatings.Infrastructure.Extensions;

namespace src.DriverRatings.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ApiControllerBase
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IMemoryCache _memoryCache;

    public AccountController(IMemoryCache memoryCache, ICommandDispatcher commandDispatcher)
      : base(commandDispatcher)
    {
      this._memoryCache = memoryCache;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUser command)
    {
      Logger.Info("Register");
      await this.DispatchAsync(command);
      return Created(command.Email, new object());
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] Login command)
    {
      command.CacheId = Guid.NewGuid();
      await this.DispatchAsync(command);
      var jwt = this._memoryCache.GetJwt(command.CacheId);

      return new JsonResult(jwt);
    }

    [HttpPost("tokens/refresh")]
    public async Task<IActionResult> RefreshAccessTokenAsync([FromBody] RefreshAccessToken command)
    {
      command.CacheId = Guid.NewGuid();
      await this.DispatchAsync(command);
      var jwt = this._memoryCache.GetJwt(command.CacheId);

      return new JsonResult(jwt);
    }

    [HttpPost("tokens/revoke")]
    public async Task<IActionResult> RevokeAccessTokenAsync([FromBody] RevokeRefreshToken command)
    {
      await this.DispatchAsync(command);
      return Ok();
    }

    [Authorize]
    [HttpGet("check-auth")]
    public IActionResult GetAuth()
    {
      return Content($"You are authorized!. Hello {this.User.Identity.Name}!");
    }
  }
}