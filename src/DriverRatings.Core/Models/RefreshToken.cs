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
      this.UserId = userId;
      this.SetToken(token);
      this.CreatedAt = DateTime.UtcNow;
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