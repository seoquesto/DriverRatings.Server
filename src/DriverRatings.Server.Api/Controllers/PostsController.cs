using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NLog;
using src.DriverRatings.Server.Infrastructure.Commands;
using src.DriverRatings.Server.Infrastructure.Commands.Comments;
using src.DriverRatings.Server.Infrastructure.Commands.Posts;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Queries;
using src.DriverRatings.Server.Infrastructure.Queries.Comments;
using src.DriverRatings.Server.Infrastructure.Queries.Posts;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Api.Controllers
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

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreatePostAsync([FromBody] CreatePost command)
    {
      _logger.Info($"Call create post api (user id: {this.UserId}).");
      var postId = await this.DispatchCommandAsync<CreatePost, Guid>(command);
      return Created($"posts/{postId}", new object());
    }

    [Authorize]
    [HttpPost("comment")]
    public async Task<IActionResult> CreatePostCommentAsync([FromBody] CreateComment command)
    {
      _logger.Info($"Call create comment api (user id: {UserId}).");
      var commentId = await this.DispatchCommandAsync<CreateComment, Guid>(command);
      return Created($"posts/{command.PostId}/{commentId}", new object());
    }

    [HttpGet("{postId}")]
    public async Task<IActionResult> GetPostByIdAsync(Guid postId)
    {
      var query = new GetPostById { PostId = postId };
      var postDto = await this.DispatchQueryAsync<GetPostById, PostDto>(query);
      return Ok(postDto);
    }

    [HttpGet("{postId}/{commentId}")]
    public async Task<IActionResult> GetPostCommentAsync(Guid postId, Guid commentId)
    {
      var command = new GetCommentById { PostId = postId, CommentId = commentId };
      var comment = await this.DispatchQueryAsync<GetCommentById, PostCommentDto>(command);
      return Ok(comment);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetPostsAsync()
    {
      var query = new GetAllPosts();
      var posts = await this.DispatchQueryAsync<GetAllPosts, IEnumerable<PostDto>>(query);
      return Ok(posts);
    }

    [HttpGet("{plateIdentifier}/{plateNumber}/all")]
    public async Task<IActionResult> GetPostsAsync(string plateIdentifier, string plateNumber)
    {
      var query = new GetPosts { PlateIdentifier = plateIdentifier, PlateNumber = plateNumber };
      var posts = await this.DispatchQueryAsync<GetPosts, IEnumerable<PostDto>>(query);
      return Ok(posts);
    }

    [Authorize]
    [HttpDelete("{postId}")]
    public async Task<IActionResult> DeletePostAsync(Guid postId)
    {
      _logger.Info($"Call delete post api (user id: {UserId}, post id: {postId}).");
      var deletePost = new DeletePost { PostId = postId };
      await this.DispatchCommandAsync(deletePost);
      return Ok();
    }
  }
}