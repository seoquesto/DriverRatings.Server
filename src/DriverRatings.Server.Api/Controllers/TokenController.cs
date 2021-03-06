using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using src.DriverRatings.Server.Infrastructure.Commands;
using src.DriverRatings.Server.Infrastructure.Commands.Token;
using src.DriverRatings.Server.Infrastructure.Extensions;
using src.DriverRatings.Server.Infrastructure.Queries;

namespace src.DriverRatings.Server.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TokenController : ApiControllerBase
  {
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IMemoryCache _memoryCache;

    public TokenController(
      IMemoryCache memoryCache,
      ICommandDispatcher commandDispatcher,
      IQueryDispatcher queryDispatcher)
      : base(commandDispatcher, queryDispatcher)
      => this._memoryCache = memoryCache;

    [Authorize]
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAccessTokenAsync([FromBody] RefreshAccessToken command)
    {
      _logger.Info($"Call refresh access token api. User id: {this.UserId}.");
      command.CacheId = Guid.NewGuid();
      await this.DispatchCommandAsync(command);
      var jwt = this._memoryCache.GetJwt(command.CacheId);

      return Ok(jwt);
    }

    [Authorize]
    [HttpPost("revoke")]
    public async Task<IActionResult> RevokeAccessTokenAsync([FromBody] RevokeRefreshToken command)
    {
      _logger.Info($"Call revoke access token api. User id: {this.UserId}.");
      await this.DispatchCommandAsync(command);
      return NoContent();
    }
  }
}