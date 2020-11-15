using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;

namespace src.DriverRatings.Infrastructure.Repositories
{
  public class UsersRepository : IUsersRepository, IMongoRepository
  {
    private const string CollectionName = "users";
    private readonly IMongoCollection<User> _users;

    public UsersRepository(IMongoDatabase mongoDatabase)
    {
      this._users = mongoDatabase.GetCollection<User>("users");
    }

    public async Task AddAsync(User user)
      => await this._users.InsertOneAsync(user);

    public async Task<User> GetAsync(Expression<Func<User, bool>> predicate)
      => await this._users.Find(predicate).SingleOrDefaultAsync();

    public async Task<IReadOnlyCollection<User>> FindAsync(Expression<Func<User, bool>> predicate)
      => await this._users.Find(predicate).ToListAsync();

    public async Task DeleteAsync(Expression<Func<User, bool>> predicate)
      => await this._users.DeleteOneAsync(predicate);

    public async Task UpdateAsync(User user, Expression<Func<User, bool>> predicate)
      => await this._users.ReplaceOneAsync(predicate, user);
  }
}