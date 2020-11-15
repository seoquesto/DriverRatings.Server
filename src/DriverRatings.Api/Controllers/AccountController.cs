using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NLog;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Users;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Extensions;
using src.DriverRatings.Infrastructure.Queries;

namespace src.DriverRatings.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class AccountController : ApiControllerBase
  {
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly IMemoryCache _memoryCache;

    public AccountController(
      IMemoryCache memoryCache, 
      ICommandDispatcher commandDispatcher, 
      IQueryDispatcher queryDispatcher)
      : base(commandDispatcher, queryDispatcher)
      => this._memoryCache = memoryCache;

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] CreateUser command)
    {
      Logger.Info($"Call register user api. Email {command.Email}");
      var userDto = await this.DispatchCommandAsync<CreateUser, UserDto>(command);
      return Created($"users/{userDto.Email}", new object());
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] Login command)
    {
      Logger.Info($"Call login user api. User name {command.Username}");
      command.CacheId = Guid.NewGuid();
      await this.DispatchCommandAsync(command);
      var jwt = this._memoryCache.GetJwt(command.CacheId);

      return Ok(jwt);
    }

    [Authorize]
    [HttpGet("me")]
    public IActionResult GetAuth()
      => Content($"You are authorized!. Hello {this.User.Identity.Name}!");
  }
}