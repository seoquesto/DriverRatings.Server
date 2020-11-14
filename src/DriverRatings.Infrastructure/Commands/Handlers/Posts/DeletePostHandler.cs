using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Commands.Posts;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Commands.Handlers.Posts
{
  public class DeletePostHandler : ICommandHandler<DeletePost>
  {
    private readonly IPostsService _postsService;
    public DeletePostHandler(IPostsService postService)
      => (_postsService) = (postService);
      
    public async Task HandleAsync(DeletePost command)
      => await this._postsService.DeletePostAsync(command.PostId);
  }
}