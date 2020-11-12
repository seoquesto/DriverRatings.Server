using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Posts;
using src.DriverRatings.Infrastructure.Queries;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Api.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class PostsController : ApiControllerBase
  {
    private readonly IPostsService postsService;

    public PostsController(
      ICommandDispatcher commandDispatcher,
      IPostsService postsService,
      IQueryDispatcher queryDispatcher)
      : base(commandDispatcher, queryDispatcher)
      => this.postsService = postsService;

    [HttpGet("{postId}")]
    public async Task<IActionResult> Get(Guid postId)
    {
      var post = await this.postsService.GetByPostId(postId);
      if (post is null)
      {
        return NotFound();
      }

      return Ok(post);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePost command)
    {
      var postId = await this.DispatchCommandAsync<CreatePost, Guid>(command);
      return Created($"posts/{postId}", new object());
    }
  }
}