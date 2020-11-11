using System;
using src.DriverRatings.Core.Exceptions;

namespace src.DriverRatings.Core.Models
{
  public class RefreshToken
  {
    public Guid UserId { get; protected set; }
    public string Token { get; protected set; }
    public bool Revoked { get; protected set; }

    protected RefreshToken()
    {
    }

    public RefreshToken(Guid userId, string token, bool revoked = false)
    {
      this.SetUserId(userId);
      this.SetToken(token);
      this.Revoked = revoked;
    }

    private void SetUserId(Guid userId)
    {
      if (userId == null)
      {
        throw new DomainException(RefreshTokenErrorCodes.EmptyRefreshTokenUserId, "User id cannot be empty!.");
      }

      if (this.UserId == userId)
      {
        return;
      }

      this.UserId = userId;
    }

    public void SetToken(string token)
    {
      if (string.IsNullOrEmpty(token))
      {
        throw new DomainException(RefreshTokenErrorCodes.EmptyRefreshToken, "Refresh token cannot be empty!.");
      }
      if (Token == token)
      {
        return;
      }
      this.Token = token;
    }

    public void Revoke()
    {
      if (this.Revoked == true)
      {
        return;
      }
      this.Revoked = true;
    }
  }
}