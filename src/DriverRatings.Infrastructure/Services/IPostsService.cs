using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services
{
  public interface IPostsService : IService
  {
    Task AddPostAsync(Guid userId, string content);
    Task<PostDto> GetByPostId(Guid id);
  }
}