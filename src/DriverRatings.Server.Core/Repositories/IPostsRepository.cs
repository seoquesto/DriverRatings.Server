using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using src.DriverRatings.Server.Core.Models;

namespace src.DriverRatings.Server.Core.Repositories
{
  public interface IPostsRepository
  {
    Task AddAsync(Post post);
    Task<Post> GetAsync(Expression<Func<Post, bool>> predicate);
    Task<IReadOnlyCollection<Post>> FindAsync(Expression<Func<Post, bool>> predicate);
    Task UpdateAsync(Post post, Expression<Func<Post, bool>> predicate);
    Task DeleteAsync(Expression<Func<Post, bool>> predicate);
  }
}
