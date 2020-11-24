using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Queries.Comments;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Queries.Handlers.Comments
{
  public class GetCommentByIdHandler : IQueryHandler<GetCommentById, PostCommentDto>
  {
    private readonly IPostsService _postsService;

    public GetCommentByIdHandler(IPostsService postService)
      => (_postsService) = (postService);

    public async Task<PostCommentDto> HandleAsync(GetCommentById query)
      => await this._postsService.GetCommentAsync(query.PostId, query.CommentId);
  }
}