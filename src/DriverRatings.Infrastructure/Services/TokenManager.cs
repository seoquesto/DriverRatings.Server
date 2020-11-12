using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using src.DriverRatings.Core.Models;
using src.DriverRatings.Core.Repositories;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Exceptions;
using src.DriverRatings.Infrastructure.Services.Interfaces;

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

    public async Task<JwtDto> RefreshAccessToken(string refreshToken)
    {
      var refToken = await this._refreshTokensRepository.GetAsync(refreshToken);
      if (refreshToken is null)
      {
        throw new ServiceException(TokenManagerErrorCodes.RefreshTokenNotFound, "Refresh token was not found.");
      }
      if (refToken.Revoked)
      {
        throw new ServiceException(TokenManagerErrorCodes.RefreshTokenRevoked, "Refresh token was revoked");
      }
      var jwt = this._jwtHandler.CreateToken(refToken.UserId, "user");
      jwt.RefreshToken = refToken.Token;

      return jwt;
    }

    public async Task RevokeRefreshToken(string refreshToken)
    {
      var refToken = await this._refreshTokensRepository.GetAsync(refreshToken);
      if (refreshToken is null)
      {
        throw new ServiceException(TokenManagerErrorCodes.RefreshTokenNotFound, "Refresh token was not found.");
      }
      if (refToken.Revoked)
      {
        throw new ServiceException(TokenManagerErrorCodes.RefreshTokenRevoked, "Refresh token was revoked");
      }
      refToken.Revoke();
      await this._refreshTokensRepository.UpdateAsync(refToken);
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
