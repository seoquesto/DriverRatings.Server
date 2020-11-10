using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Core.Models;

namespace src.DriverRatings.Core.Repositories
{
  public interface IPostsRepository
  {
    Task<Post> GetByPostId(Guid postID);
    Task<IEnumerable<Post>> GetAllByUserId(Guid userId);
    Task AddAsync(Post post);
    Task RemoveAsync(Post post);
    Task Update(Post post);
  }
}
