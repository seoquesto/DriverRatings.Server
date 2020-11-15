using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.DriverRatings.Api.Controllers;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Queries;
using src.DriverRatings.Infrastructure.Queries.Users;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace DriverRatings.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class UsersController : ApiControllerBase
  {
    private readonly IUsersService _usersService;

    public UsersController(
      IUsersService usersService,
      ICommandDispatcher commandDispatcher,
      IQueryDispatcher queryDispatcher)
      : base(commandDispatcher, queryDispatcher)
      => (_usersService) = (usersService);

    [HttpGet("{username}")]
    public async Task<IActionResult> GetAsync(string username)
    {
      var query = new GetUserByName { Username = username };
      var user = await this.DispatchQueryAsync<GetUserByName, UserDto>(query);
      return Ok(user);
    }
  }
}
