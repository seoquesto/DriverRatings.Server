using System;
using src.DriverRatings.Core.Exceptions;

namespace src.DriverRatings.Core.Models
{
  public class RefreshToken
  {
    public Guid UserId { get; protected set; }
    public string Token { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? RevokedAt { get; protected set; }
    public bool Revoked => this.RevokedAt.HasValue;

    protected RefreshToken()
    {
    }

    public RefreshToken(Guid userId, string token, bool revoked = false)
    {
      this.SetUserId(userId);
      this.SetToken(token);
      this.CreatedAt = DateTime.UtcNow;
    }

    private void SetUserId(Guid userId)
    {
      if (userId == null)
      {
        throw new InvalidIdException("Invalid user id.");
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
        throw new InvalidRefreshTokenException();
      }
      if (Token == token)
      {
        return;
      }
      this.Token = token;
    }

    public void Revoke()
    {
      if (this.Revoked)
      {
        throw new RevokedRefreshTokenException();
      }

      this.RevokedAt = DateTime.UtcNow;
    }
  }
}