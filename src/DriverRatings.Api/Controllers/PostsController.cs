using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Posts;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Api.Controllers
{

  [ApiController]
  [Route("[controller]")]
  public class PostsController : ApiControllerBase
  {
    private readonly IPostsService postsService;

    public PostsController(ICommandDispatcher commandDispatcher, IPostsService postsService) : base(commandDispatcher)
    {
      this.postsService = postsService;
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> Get(Guid postId)
    {
      var post = await this.postsService.GetByPostId(postId);
      if (post == null)
      {
        return NotFound();
      }

      return Ok(post);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePost command)
    {
      await this.DispatchAsync(command);

      return Created($"posts", new object());
    }
  }
}