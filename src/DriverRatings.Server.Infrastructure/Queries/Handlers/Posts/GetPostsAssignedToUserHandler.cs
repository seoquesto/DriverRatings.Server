using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Queries.Posts;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Queries.Handlers.Posts
{
  public class GetPostsAssignedToUserHandler : IQueryHandler<GetPostsAssignedToUser, IEnumerable<PostDto>>
  {
    private readonly IPostsService _postsService;

    public GetPostsAssignedToUserHandler(IPostsService postsService)
      => (_postsService) = (postsService);

    public async Task<IEnumerable<PostDto>> HandleAsync(GetPostsAssignedToUser query)
      => await _postsService.GetPostsAssignedToUser(query.Username);
  }
}