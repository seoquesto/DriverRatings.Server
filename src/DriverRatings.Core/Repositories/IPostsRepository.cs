using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Core.Models;

namespace src.DriverRatings.Core.Repositories
{
  public interface IPostsRepository
  {
    Task<Post> GetByPostIdAsync(Guid postId);
    Task<IEnumerable<Post>> GetAllByUserIdAsync(Guid userId);
    Task AddAsync(Post post);
    Task RemoveAsync(Post post);
    Task UpdateAsync(Post post);
  }
}
