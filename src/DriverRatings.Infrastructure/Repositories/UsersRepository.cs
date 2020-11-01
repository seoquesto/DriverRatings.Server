using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using src.DriverRatings.Core.Models;

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

    public async Task<User> GetByIdAsync(Guid id)
      => await this._users.AsQueryable().FirstOrDefaultAsync(x => x.Id.Equals(id));

    public async Task<User> GetByUsernameAsync(string username)
      => await this._users.AsQueryable().FirstOrDefaultAsync(x => x.Username.Equals(username));

    public async Task AddAsync(User user)
      => await this._users.InsertOneAsync(user);

    public async Task RemoveAsync(User user)
      => await this._users.DeleteOneAsync(x => x.Id.Equals(user.Id));

    public async Task Update(User user)
      => await this._users.ReplaceOneAsync(x => x.Id.Equals(user.Id), user);
  }
}