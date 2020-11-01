using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.DriverRatings.Core.Models;

namespace src.DriverRatings.Infrastructure.Repositories
{
  public class InMemoryUsersRepository : IUsersRepository, IRepository
  {
    private static List<User> UsersList = new List<User>();

    public async Task AddAsync(User user)
    {
      await Task.CompletedTask;
      UsersList.Add(user);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
      await Task.CompletedTask;
      return UsersList;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
      await Task.CompletedTask;
      return UsersList.FirstOrDefault(x => x.Id.Equals(id));
    }

    public async Task<User> GetByEmailAsync(string email)
    {
      await Task.CompletedTask;
      return UsersList.FirstOrDefault(x => x.Email.Equals(email));
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
      await Task.CompletedTask;
      return UsersList.FirstOrDefault(x => x.Username.Equals(username));
    }

    public async Task RemoveAsync(User user)
    {
      var userToRemove = await this.GetByIdAsync(user.Id);
      UsersList.Remove(userToRemove);
    }

    public async Task Update(User user)
    {
      await Task.CompletedTask;
      throw new NotImplementedException();
    }
  }

  public interface IUsersRepository 
  {
    Task<User> GetByIdAsync(Guid id);
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByUsernameAsync(string username);
    Task AddAsync(User user);
    Task RemoveAsync(User user);
    Task Update(User user);
    Task<IEnumerable<User>> GetAll();
  }
}