using System;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Exceptions;
using src.DriverRatings.Core.Repositories;
using src.DriverRatings.Infrastructure.Services.Interfaces;
using src.DriverRatings.Core.Exceptions;
using src.DriverRatings.Infrastructure.Extensions;
using NLog;

namespace src.DriverRatings.Infrastructure.Services
{
  public class UsersService : IUsersService
  {
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IEncrypter _encrypter;
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

    public UsersService(IUsersRepository usersRepository, IMapper mapper, IEncrypter encrypter)
    {
      this._usersRepository = usersRepository;
      this._mapper = mapper;
      this._encrypter = encrypter;
    }

    public async Task RegisterAsync(Guid userId, string username, string email, string password, string role)
    {
      if (!StringExtensions.IsValidEmail(email))
      {
        _logger.Error($"Invalid email: {email}.");
        throw new InvalidEmailException(email);
      }
      if (string.IsNullOrEmpty(username))
      {
        _logger.Error($"Invalid username: {username}.");
        throw new InvalidUsernameException(username);
      }

      var user = await this._usersRepository.GetByEmailAsync(email);
      if (user is { })
      {
        _logger.Error($"Email in use: {email}.");
        throw new EmailInUseException(email);
      }

      user = await this._usersRepository.GetByUsernameAsync(username);
      if (user is { })
      {
        _logger.Error($"Username in use: {username}.");
        throw new UsernameInUseException(username);
      }

      var userRole = string.IsNullOrWhiteSpace(role) ? "user" : role.ToLowerInvariant();
      var salt = this._encrypter.GetSalt(password);
      var hash = this._encrypter.GetHash(password, salt);
      user = new User(userId, username, email, hash, salt, userRole);

      _logger.Info($"Created an account for the user with id: {user.UserId.ToString()}.");
      await this._usersRepository.AddAsync(user);
    }

    public async Task<UserDto> GetByEmailAsync(string email)
    {
      var user = await this._usersRepository.GetByEmailAsync(email);

      return this._mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByIdAsync(Guid userId)
    {
      var user = await this._usersRepository.GetByIdAsync(userId);

      return this._mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByUsernameAsync(string username)
    {
      var user = await this._usersRepository.GetByUsernameAsync(username);

      return this._mapper.Map<UserDto>(user);
    }

    public async Task LoginAsync(string email, string password)
    {
      if (!StringExtensions.IsValidEmail(email))
      {
        _logger.Error($"Invalid email: {email}.");
        throw new InvalidEmailException(email);
      }

      var user = await this._usersRepository.GetByEmailAsync(email);
      if (user is null)
      {
        throw new InvalidCredentialsException();
      }

      var hash = this._encrypter.GetHash(password, user.Salt);
      if (user.Password != hash)
      {
        _logger.Error($"Invalid password for user id: {user.UserId.ToString()}.");
        throw new InvalidCredentialsException();
      }
    }
  }
}