using System;
using src.DriverRatings.Server.Core.Exceptions;

namespace src.DriverRatings.Server.Core.Models
{
  public class CreatorInfo
  {
    public Guid UserId { get; protected set; }
    public string Username { get; protected set; }

    protected CreatorInfo()
    {
    }

    public CreatorInfo(Guid userId, string username)
    {
      this.UserId = userId;
      this.SetUsername(username);
    }

    private void SetUsername(string username)
    {
      var fixedUsername = username?.Trim().ToLowerInvariant();
      if (string.IsNullOrEmpty(fixedUsername))
      {
        throw new InvalidCredentialsException("User name cannot be empty.");
      }

      if (this.Username == fixedUsername)
      {
        return;
      }

      this.Username = fixedUsername;
    }
  }
}