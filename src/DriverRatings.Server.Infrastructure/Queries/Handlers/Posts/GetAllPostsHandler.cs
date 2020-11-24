using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Queries.Posts;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Queries.Handlers.Posts
{
  public class GetAllPostsHandler : IQueryHandler<GetAllPosts, IEnumerable<PostDto>>
  {
    private readonly IPostsService _postsService;

    public GetAllPostsHandler(IPostsService postsService, IMapper mapper)
      => (_postsService) = (postsService);

    public async Task<IEnumerable<PostDto>> HandleAsync(GetAllPosts query)
      => await this._postsService.GetAllPostsAsync();
  }
}