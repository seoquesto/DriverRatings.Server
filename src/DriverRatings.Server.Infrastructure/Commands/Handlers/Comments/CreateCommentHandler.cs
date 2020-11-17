using System;
using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.Commands.Comments;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Commands.Handlers.Comments
{
  public class CreateCommentHandler : ICommandHandler<CreateComment, Guid>
  {
    private readonly IPostsService _postsService;
    public CreateCommentHandler(IPostsService postsService)
      => (_postsService) = (postsService);

    public async Task<Guid> HandleAsync(CreateComment command)
    {
      var commentId = Guid.NewGuid();
      await _postsService.AddCommentAsync(command.UserId, command.PostId, commentId, command.Content);
      return commentId;
    }
  }
}