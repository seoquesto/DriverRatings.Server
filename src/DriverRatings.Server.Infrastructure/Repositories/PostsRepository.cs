using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Core.Repositories;

namespace src.DriverRatings.Server.Infrastructure.Repositories
{
  public class PostsRepository : IPostsRepository, IMongoRepository
  {
    private const string CollectionName = "posts";
    private readonly IMongoCollection<Post> _posts;

    public PostsRepository(IMongoDatabase mongoDatabase)
    {
      this._posts = mongoDatabase.GetCollection<Post>(CollectionName);
    }

    public async Task AddAsync(Post post)
      => await this._posts.InsertOneAsync(post);

    public async Task<Post> GetAsync(Expression<Func<Post, bool>> predicate)
      => await this._posts.Find(predicate).SingleOrDefaultAsync();

    public async Task<IReadOnlyCollection<Post>> FindAsync(Expression<Func<Post, bool>> predicate)
      => await this._posts.Find(predicate).ToListAsync();

    public async Task UpdateAsync(Post post, Expression<Func<Post, bool>> predicate)
      => await this._posts.ReplaceOneAsync(predicate, post);

    public async Task DeleteAsync(Expression<Func<Post, bool>> predicate)
      => await this._posts.DeleteOneAsync(predicate);
  }
}