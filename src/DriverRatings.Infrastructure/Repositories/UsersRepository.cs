using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;

namespace src.DriverRatings.Infrastructure.Repositories
{
  public class UsersRepository : IUsersRepository, IMongoRepository
  {
    private readonly IMongoCollection<User> _users;

    public UsersRepository(IMongoDatabase mongoDatabase)
    {
      this._users = mongoDatabase.GetCollection<User>("users");
    }

    public async Task<IEnumerable<User>> GetAll()
      => await this._users.AsQueryable().ToListAsync();

    public async Task<User> GetByEmailAsync(string email)
      => await this._users.AsQueryable().FirstOrDefaultAsync(x => x.Email.Equals(email));

    public async Task<User> GetByIdAsync(Guid userId)
      => await this._users.AsQueryable().FirstOrDefaultAsync(x => x.UserId.Equals(userId));

    public async Task<User> GetByUsernameAsync(string username)
      => await this._users.AsQueryable().FirstOrDefaultAsync(x => x.Username.Equals(username));

    public async Task AddAsync(User user)
      => await this._users.InsertOneAsync(user);

    public async Task RemoveAsync(User user)
      => await this._users.DeleteOneAsync(x => x.UserId.Equals(user.UserId));

    public async Task Update(User user)
      => await this._users.ReplaceOneAsync(x => x.UserId.Equals(user.UserId), user);
  }
}