using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using src.DriverRatings.Core.Models;

namespace src.DriverRatings.Core.Repositories
{
  public interface IUsersRepository
  {
    Task AddAsync(User user);
    Task<User> GetAsync(Expression<Func<User, bool>> predicate);
    Task<IReadOnlyCollection<User>> FindAsync(Expression<Func<User, bool>> predicate);
    Task UpdateAsync(User user, Expression<Func<User, bool>> predicate);
    Task DeleteAsync(Expression<Func<User, bool>> predicate);
  }
}