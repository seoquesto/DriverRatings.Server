using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Token;
using src.DriverRatings.Infrastructure.Extensions;

namespace src.DriverRatings.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TokenController : ApiControllerBase
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IMemoryCache _memoryCache;

    public TokenController(IMemoryCache memoryCache, ICommandDispatcher commandDispatcher)
      : base(commandDispatcher)
    {
      this._memoryCache = memoryCache;
    }

    [Authorize]
    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshAccessTokenAsync([FromBody] RefreshAccessToken command)
    {
      command.CacheId = Guid.NewGuid();
      await this.DispatchAsync(command);
      var jwt = this._memoryCache.GetJwt(command.CacheId);

      return new JsonResult(jwt);
    }

    [Authorize]
    [HttpPost("revoke")]
    public async Task<IActionResult> RevokeAccessTokenAsync([FromBody] RevokeRefreshToken command)
    {
      await this.DispatchAsync(command);
      return Ok();
    }
  }
}