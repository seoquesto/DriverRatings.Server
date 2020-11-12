using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;

namespace src.DriverRatings.Infrastructure.Repositories
{
  public class PostsRepository : IPostsRepository, IMongoRepository
  {
    private readonly IMongoCollection<Post> _posts;

    public PostsRepository(IMongoDatabase mongoDatabase)
    {
      this._posts = mongoDatabase.GetCollection<Post>("posts");
    }

    public async Task AddAsync(Post post)
      => await this._posts.InsertOneAsync(post);

    public async Task<IEnumerable<Post>> GetAllByUserIdAsync(Guid userId)
      => await this._posts.Find(x => x.UserInfo.UserId.Equals(userId)).ToListAsync();

    public async Task<Post> GetByPostIdAsync(Guid postId)
      => await this._posts.Find(x => x.PostId.Equals(postId)).SingleOrDefaultAsync();

    public async Task RemoveAsync(Post post)
      => await this._posts.DeleteOneAsync(x => x.PostId.Equals(post.PostId));

    public async Task UpdateAsync(Post post)
      => await this._posts.ReplaceOneAsync(x => x.PostId.Equals(post.PostId), post);
  }
}