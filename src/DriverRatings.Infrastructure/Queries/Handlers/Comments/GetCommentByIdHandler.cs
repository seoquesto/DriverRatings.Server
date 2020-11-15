using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Queries.Comments;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Queries.Handlers.Comments
{
  public class GetCommentByIdHandler : IQueryHandler<GetCommentById, CommentDto>
  {
    private readonly IPostsService _postsService;

    public GetCommentByIdHandler(IPostsService postService)
      => (_postsService) = (postService);

    public async Task<CommentDto> HandleAsync(GetCommentById query)
      => await this._postsService.GetCommentAsync(query.PostId, query.CommentId);
  }
}