using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services
{
  public class TokenManager : ITokenManager
  {
    private readonly IRefreshTokensRepository _refreshTokensRepository;
    private readonly IJwtHandler _jwtHandler;
    private readonly IPasswordHasher<UserDto> _passwordHasher;

    public TokenManager(IRefreshTokensRepository refreshTokensRepository, IJwtHandler jwtHandler, IPasswordHasher<UserDto> passwordHasher)
    {
      this._refreshTokensRepository = refreshTokensRepository;
      this._jwtHandler = jwtHandler;
      this._passwordHasher = passwordHasher;
    }

    public async Task<JwtDto> RefreshAccessToken(string token)
    {
      var refreshToken = await this._refreshTokensRepository.GetAsync(token);
      if (refreshToken == null)
      {
        throw new Exception("Refresh token was not found.");
      }
      if (refreshToken.Revoked)
      {
        throw new Exception("Refresh token was revoked");
      }
      var jwt = this._jwtHandler.CreateToken(refreshToken.UserId, "user");
      jwt.RefreshToken = refreshToken.Token;

      return jwt;
    }

    public async Task RevokeRefreshToken(string token)
    {
      var refreshToken = await this._refreshTokensRepository.GetAsync(token);
      if (refreshToken == null)
      {
        throw new Exception("Refresh token was not found.");
      }
      if (refreshToken.Revoked)
      {
        throw new Exception("Refresh token was already revoked.");
      }
      refreshToken.Revoke();
      await this._refreshTokensRepository.UpdateAsync(refreshToken);
    }

    public async Task<string> GenerateRefreshToken(UserDto userDto)
    {
      var token = this._passwordHasher
                .HashPassword(userDto, Guid.NewGuid().ToString())
                .Replace("+", string.Empty)
                .Replace("=", string.Empty)
                .Replace("/", string.Empty);

      await this._refreshTokensRepository.AddAsync(new RefreshToken(userDto.UserId, token));
      return token;
    }
  }
}
