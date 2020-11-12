using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Commands.Posts;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Commands.Handlers.Posts
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