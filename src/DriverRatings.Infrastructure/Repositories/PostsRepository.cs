using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using src.DriverRatings.Core.Models;

namespace src.DriverRatings.Infrastructure.Repositories
{
  public class PostsRepository : IPostsRepository, IMongoRepository
  {
    public Task AddAsync(Post post)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<Post>> GetAllByUserId(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task<Post> GetByPostId(Guid postID)
    {
      throw new NotImplementedException();
    }

    public Task RemoveAsync(Post post)
    {
      throw new NotImplementedException();
    }

    public Task Update(Post post)
    {
      throw new NotImplementedException();
    }
  }
}