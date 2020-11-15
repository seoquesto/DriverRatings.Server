using System;
using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Core.Repositories;
using src.DriverRatings.Infrastructure.Services.Interfaces;
using NLog;

namespace src.DriverRatings.Infrastructure.Services
{
  public class UsersService : IUsersService
  {
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IEncrypter _encrypter;

    public UsersService(IUsersRepository usersRepository, IMapper mapper, IEncrypter encrypter)
    {
      this._usersRepository = usersRepository;
      this._mapper = mapper;
      this._encrypter = encrypter;
    }

    public async Task<UserDto> GetByEmailAsync(string email)
    {
      var modifiedEmail = email?.Trim().ToLowerInvariant();
      var user = await this._usersRepository.GetAsync(x => x.Email == modifiedEmail);
      return this._mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByIdAsync(Guid userId)
    {
      var user = await this._usersRepository.GetAsync(x => x.UserId == userId);
      return this._mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetByUsernameAsync(string username)
    {
      var modifiedUsername = username?.Trim().ToLowerInvariant();
      var user = await this._usersRepository.GetAsync(x => x.Username == modifiedUsername);
      return this._mapper.Map<UserDto>(user);
    }
  }
}