using System;
using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.Commands.Posts;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Commands.Handlers.Posts
{
  public class CreatePostHandler : ICommandHandler<CreatePost, Guid>
  {
    private readonly IPostsService _postsService;

    public CreatePostHandler(IPostsService postsService)
      => _postsService = postsService;

    public async Task<Guid> HandleAsync(CreatePost command)
      => await this._postsService.AddPostAsync(command.UserId, command.Content);
  }
}