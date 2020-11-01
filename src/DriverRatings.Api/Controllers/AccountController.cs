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
    
    public AccountController(IMemoryCache memoryCache, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
    {
      this._memoryCache = memoryCache;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUser command)
    {
      Logger.Info("Register");
      await this.DispatchAsync<CreateUser>(command);
      return Created(command.Email, new object());
    }

     [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] Login command)
    {
      command.TokenId = Guid.NewGuid();
      await this.DispatchAsync<Login>(command);
      var jwt = this._memoryCache.GetJwt(command.TokenId);

      return new JsonResult(jwt);
    }

    [Authorize]
    [HttpGet("auth")]
    public IActionResult GetAuth()
    {
      return Content("You are authorized!.");
    }
  }
}