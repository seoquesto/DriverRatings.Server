using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.Commands.Posts;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Commands.Handlers.Posts
{
  public class DeletePostHandler : ICommandHandler<DeletePost>
  {
    private readonly IPostsService _postsService;
    public DeletePostHandler(IPostsService postService)
      => (_postsService) = (postService);
      
    public async Task HandleAsync(DeletePost command)
      => await this._postsService.DeletePostAsync(command.UserId, command.PostId);
  }
}