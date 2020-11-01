using System;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Repositories;

namespace src.DriverRatings.Infrastructure.Services
{
  public class UsersService : IUsersService
  {
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IEncrypter _encrypter;

    public UsersService(IUsersRepository usersRepository, IMapper mapper, IEncrypter encrypter)
    {
      this._usersRepository = usersRepository;
      this._mapper = mapper;
      this._encrypter = encrypter;
    }

    public async Task RegisterAsync(Guid userId, string username, string email, string password)
    {
      var user = await this._usersRepository.GetByEmailAsync(email);
      if (user != null)
      {
        throw new ServiceException(UsersServiceErrorCodes.EmailInUse, $@"User with email ""{email}"" already exist!.");
      }

      user = await this._usersRepository.GetByUsernameAsync(username);
      if (user != null)
      {
        throw new ServiceException(UsersServiceErrorCodes.EmailInUse, $@"User with email ""{email}"" already exist!.");
      }

      var salt = this._encrypter.GetSalt(password);
      var hash = this._encrypter.GetHash(password, salt);

      user = new User(userId, username, email, hash, salt);
      await this._usersRepository.AddAsync(user);
    }

    public async Task<UserDto> GetByEmailAsync(string email)
    {
      var user = await this._usersRepository.GetByEmailAsync(email);

      return this._mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByIdAsync(Guid id)
    {
      var user = await this._usersRepository.GetByIdAsync(id);

      return this._mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByUsernameAsync(string username)
    {
      var user = await this._usersRepository.GetByUsernameAsync(username);

      return this._mapper.Map<UserDto>(user);
    }

    public async Task LoginAsync(string email, string password)
    {
      var user = await this._usersRepository.GetByEmailAsync(email);
      if (user == null)
      {
        throw new ServiceException(UsersServiceErrorCodes.InvalidCredentials, "Invalid credentials!.");
      }

      var hash = this._encrypter.GetHash(password, user.Salt);
      if (user.Password != hash)
      {
        throw new ServiceException(UsersServiceErrorCodes.InvalidCredentials, "Invalid credentials!.");
      }
    }
  }
}