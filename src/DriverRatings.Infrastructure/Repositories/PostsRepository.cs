using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;

namespace src.DriverRatings.Infrastructure.Repositories
{
  public class PostsRepository : IPostsRepository, IMongoRepository
  {
    public Task AddAsync(Post post)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAllByUserIdAsync(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task<Post> GetByPostIdAsync(Guid postID)
    {
      throw new NotImplementedException();
    }

    public Task RemoveAsync(Post post)
    {
      throw new NotImplementedException();
    }

    public Task UpdateAsync(Post post)
    {
      throw new NotImplementedException();
    }
  }
}