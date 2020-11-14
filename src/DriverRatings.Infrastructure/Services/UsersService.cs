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
      var modifiedEmail = email?.Trim().ToLowerInvariant();
      var modifiedUsername = username?.Trim().ToLowerInvariant();

      if (!StringExtensions.IsValidEmail(modifiedEmail))
      {
        _logger.Error($"Invalid email: {modifiedEmail}.");
        throw new InvalidEmailException(modifiedEmail);
      }
      if (string.IsNullOrEmpty(modifiedUsername))
      {
        _logger.Error($"Invalid username: {modifiedUsername}.");
        throw new InvalidUsernameException(modifiedUsername);
      }

      var user = await this._usersRepository.GetByEmailAsync(modifiedEmail);
      if (user is { })
      {
        _logger.Error($"Email in use: {modifiedEmail}.");
        throw new EmailInUseException(modifiedEmail);
      }

      user = await this._usersRepository.GetByUsernameAsync(modifiedUsername);
      if (user is { })
      {
        _logger.Error($"Username in use: {modifiedUsername}.");
        throw new UsernameInUseException(modifiedUsername);
      }

      var userRole = string.IsNullOrWhiteSpace(role) ? "user" : role.ToLowerInvariant();
      var salt = this._encrypter.GetSalt(password);
      var hash = this._encrypter.GetHash(password, salt);
      user = new User(userId, modifiedUsername, modifiedEmail, hash, salt, userRole);

      await this._usersRepository.AddAsync(user);
      _logger.Info($"Created an account for the user with id: {user.UserId.ToString()}.");
    }

    public async Task LoginAsync(string username, string password)
    {
      var modifiedUsername = username?.Trim().ToLowerInvariant();

      if (string.IsNullOrEmpty(modifiedUsername))
      {
        _logger.Error($"Invalid username: {modifiedUsername}.");
        throw new InvalidUsernameException(modifiedUsername);
      }

      var user = await this._usersRepository.GetByUsernameAsync(modifiedUsername);
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

    public async Task<UserDto> GetByEmailAsync(string email)
    {
      var modifiedEmail = email?.Trim().ToLowerInvariant();
      var user = await this._usersRepository.GetByEmailAsync(modifiedEmail);
      return this._mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByIdAsync(Guid userId)
    {
      var user = await this._usersRepository.GetByIdAsync(userId);
      return this._mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByUsernameAsync(string username)
    {
      var modifiedUsername = username?.Trim().ToLowerInvariant();
      var user = await this._usersRepository.GetByUsernameAsync(modifiedUsername);
      return this._mapper.Map<UserDto>(user);
    }
  }
}