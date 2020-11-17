using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using NLog;
using src.DriverRatings.Server.Core.Exceptions;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Core.Repositories;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Services
{
  public class TokenManager : ITokenManager
  {
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IRefreshTokensRepository _refreshTokensRepository;
    private readonly IJwtHandler _jwtHandler;
    private readonly IPasswordHasher<UserDto> _passwordHasher;

    public TokenManager(IRefreshTokensRepository refreshTokensRepository, IJwtHandler jwtHandler, IPasswordHasher<UserDto> passwordHasher)
    {
      this._refreshTokensRepository = refreshTokensRepository;
      this._jwtHandler = jwtHandler;
      this._passwordHasher = passwordHasher;
    }

    public async Task<string> CreateRefreshTokenAsync(UserDto userDto)
    {
      var token = this._passwordHasher
                .HashPassword(userDto, Guid.NewGuid().ToString())
                .Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/", string.Empty);

      await this._refreshTokensRepository.AddAsync(new RefreshToken(userDto.UserId, token));
      _logger.Info($"Refresh token for user with id {userDto.UserId} has been created and added successfully.");
      return token;
    }

    public async Task<JwtDto> RefreshAccessToken(string refreshToken)
    {
      var refToken = await this._refreshTokensRepository.GetAsync(refreshToken);
      if (refreshToken is null)
      {
        throw new InvalidRefreshTokenException();
      }
      if (refToken.Revoked)
      {
        throw new RevokedRefreshTokenException();
      }

      var jwt = this._jwtHandler.CreateToken(refToken.UserId, "user");
      jwt.RefreshToken = refToken.Token;

      _logger.Info($"Refresh token for user with id {refToken.UserId} has been refreshed successfully.");
      return jwt;
    }

    public async Task RevokeRefreshTokenAsync(string refreshToken)
    {
      if (refreshToken is null)
      {
        throw new InvalidRefreshTokenException();
      }

      var token = await this._refreshTokensRepository.GetAsync(refreshToken);
      if (token.Revoked)
      {
        throw new RevokedRefreshTokenException();
      }

      token.Revoke();
      await this._refreshTokensRepository.UpdateAsync(token);
      _logger.Info($"Refresh token for user with id {token.UserId} has been revoked successfully.");
    }
  }
}
