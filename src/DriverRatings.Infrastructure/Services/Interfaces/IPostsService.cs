using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services.Interfaces
{
  public interface IPostsService : IService
  {
    Task<Guid> AddPostAsync(Guid userId, string content);
    Task<PostDto> GetByPostId(Guid postId);
  }
}