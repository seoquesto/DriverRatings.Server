using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Comments;
using src.DriverRatings.Infrastructure.Commands.Posts;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Queries;
using src.DriverRatings.Infrastructure.Queries.Comments;
using src.DriverRatings.Infrastructure.Queries.Posts;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Api.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class PostsController : ApiControllerBase
  {
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IPostsService postsService;

    public PostsController(
      ICommandDispatcher commandDispatcher,
      IPostsService postsService,
      IQueryDispatcher queryDispatcher)
      : base(commandDispatcher, queryDispatcher)
      => this.postsService = postsService;

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetPostByIdAsync(Guid postId)
    {
      var query = new GetPostById { PostId = postId };
      var postDto = await this.DispatchQueryAsync<GetPostById, PostDto>(query);
      return Ok(postDto);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePost command)
    {
      _logger.Info($"Call create post api. User id: {UserId}.");
      var postId = await this.DispatchCommandAsync<CreatePost, Guid>(command);
      return Created($"posts/{postId}", new object());
    }

    [Authorize]
    [HttpDelete("{postId}")]
    public async Task<IActionResult> CreatePostAsync(Guid postId)
    {
      _logger.Info($"Call delete post api. User id: {UserId}.");
      var deletePost = new DeletePost { PostId = postId };
      await this.DispatchCommandAsync(deletePost);
      return Ok();
    }

    [Authorize]
    [HttpPost("comment")]
    public async Task<IActionResult> CreatePostCommentAsync([FromBody] CreateComment command)
    {
      _logger.Info($"Call create comment api. User id: {UserId}. Post id: {command.PostId}.");
      var commentId = await this.DispatchCommandAsync<CreateComment, Guid>(command);
      return Created($"posts/{command.PostId}/{commentId}", new object());
    }

    [HttpGet("{postId}/{commentId}")]
    public async Task<IActionResult> CreatePostAsync(Guid postId, Guid commentId)
    {
      var command = new GetCommentById { PostId = postId, CommentId = commentId };
      var comment = await this.DispatchQueryAsync<GetCommentById, CommentDto>(command);
      return Ok(comment);
    }
  }
}