using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;

namespace src.DriverRatings.Infrastructure.Repositories
{
  public class InMemoryPostsRepository : IPostsRepository, IRepository
  {
    private static List<Post> PostsList = new List<Post>();

    public async Task AddAsync(Post post)
    {
      await Task.CompletedTask;
      PostsList.Add(post);
    }

    public async Task<IEnumerable<Post>> GetAllByUserIdAsync(Guid userId)
    {
      await Task.CompletedTask;
      return PostsList.Where(x => x.UserInfo.UserId.Equals(userId));
    }

    public async Task<Post> GetByPostIdAsync(Guid postId)
    {
      await Task.CompletedTask;
      return PostsList.FirstOrDefault(x => x.PostId.Equals(postId));
    }

    public async Task RemoveAsync(Post post)
    {
      var postToRemove = await this.GetByPostIdAsync(post.PostId);
      PostsList.Remove(postToRemove);
    }

    public async Task UpdateAsync(Post post)
    {
      await Task.CompletedTask;
      throw new NotImplementedException();
    }
  }
}