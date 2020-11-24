using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.DriverRatings.Server.Api.Controllers;
using src.DriverRatings.Server.Infrastructure.Commands;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Queries;
using src.DriverRatings.Server.Infrastructure.Queries.Posts;
using src.DriverRatings.Server.Infrastructure.Queries.Users;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace DriverRatings.Server.Api.Controllers
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

    [HttpGet("{username}/posts")]
    public async Task<IActionResult> GetUserPosts(string username)
    {
      var query = new GetPostsAssignedToUser { Username = username };
      var posts = await this.DispatchQueryAsync<GetPostsAssignedToUser, IEnumerable<PostDto>>(query);
      return Ok(posts);
    }
  }
}
