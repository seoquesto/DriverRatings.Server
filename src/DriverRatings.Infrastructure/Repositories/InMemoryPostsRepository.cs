using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DriverRatings.Core.Models;

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

    public async Task<IEnumerable<Post>> GetAllByUserId(Guid userId)
    {
      await Task.CompletedTask;
      return PostsList.Where(x => x.UserInfo.UserId.Equals(userId));
    }

    public async Task<Post> GetByPostId(Guid postId)
    {
      await Task.CompletedTask;
      return PostsList.FirstOrDefault(x => x.PostId.Equals(postId));
    }

    public async Task RemoveAsync(Post post)
    {
      var postToRemove = await this.GetByPostId(post.PostId);
      PostsList.Remove(postToRemove);
    }

    public async Task Update(Post post)
    {
      await Task.CompletedTask;
      throw new NotImplementedException();
    }
  }

  public interface IPostsRepository
  {
    Task<Post> GetByPostId(Guid postID);
    Task<IEnumerable<Post>> GetAllByUserId(Guid userId);
    Task AddAsync(Post post);
    Task RemoveAsync(Post post);
    Task Update(Post post);
  }
}