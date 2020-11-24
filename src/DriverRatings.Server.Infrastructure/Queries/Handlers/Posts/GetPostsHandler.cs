using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Queries.Posts;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Queries.Handlers.Posts
{
  public class GetPostsHandler : IQueryHandler<GetPosts, IEnumerable<PostDto>>
  {
    private readonly IPostsService _postsService;

    public GetPostsHandler(IPostsService postsService)
      => (_postsService) = (postsService);

    public async Task<IEnumerable<PostDto>> HandleAsync(GetPosts query)
      => await this._postsService.GetAllPostsAsync(query.PlateIdentifier, query.PlateNumber);
  }
}