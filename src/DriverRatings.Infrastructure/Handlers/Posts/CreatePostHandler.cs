using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Posts;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Handlers.Posts
{
  public class CreatePostHandler : ICommandHandler<CreatePost>
  {
    private readonly IPostsService postsService;

    public CreatePostHandler(IPostsService postsService)
    {
      this.postsService = postsService;
    }

    public async Task HandleAsync(CreatePost command)
    {
      await this.postsService.AddPostAsync(command.UserId, command.Content);
    }
  }
}