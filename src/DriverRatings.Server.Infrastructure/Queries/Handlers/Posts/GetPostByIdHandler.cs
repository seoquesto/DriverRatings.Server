using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Queries.Posts;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Queries.Handlers.Posts
{
  public class GetPostByIdHandler : IQueryHandler<GetPostById, PostDto>
  {
    private readonly IPostsService _postsService;
    private readonly IMapper _mapper;

    public GetPostByIdHandler(IPostsService postsService, IMapper mapper)
      => (_postsService, _mapper) = (postsService, mapper);

    public async Task<PostDto> HandleAsync(GetPostById query)
      => await this._postsService.GetByPostIdAsync(query.PostId);
  }
}