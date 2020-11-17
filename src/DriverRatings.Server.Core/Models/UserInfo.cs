using System;
using src.DriverRatings.Server.Core.Exceptions;

namespace src.DriverRatings.Server.Core.Models
{
  public class UserInfo
  {
    public Guid UserId { get; protected set; }
    public string Username { get; protected set; }

    protected UserInfo()
    {
    }

    public UserInfo(Guid userId, string username)
    {
      this.UserId = userId;
      this.SetUsername(username);
    }

    private void SetUsername(string username)
    {
      if (string.IsNullOrEmpty(username))
      {
        throw new InvalidCredentialsException("User name cannot be empty.");
      }

      if (this.Username == username)
      {
        return;
      }

      this.Username = username;
    }
  }
}