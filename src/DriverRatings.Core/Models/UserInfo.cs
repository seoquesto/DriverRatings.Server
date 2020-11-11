using System;
using src.DriverRatings.Core.Exceptions;

namespace src.DriverRatings.Core.Models
{
  public class UserInfo
  {
    public Guid UserId { get; protected set; }
    public string Username { get; protected set; }
    public string Email { get; protected set; }

    protected UserInfo()
    {
    }

    public UserInfo(string username, string email) : this(Guid.NewGuid(), username, email)
    {
    }

    public UserInfo(Guid userId, string username, string email)
    {
      this.SetUserId(userId);
      this.SetUsername(username);
      this.SetEmail(email);
    }

    private void SetUserId(Guid userId)
    {
      if (userId == null)
      {
        throw new DomainException(UserErrorCodes.EmptyUserId, "User id cannot be empty!.");
      }

      if (this.UserId == userId)
      {
        return;
      }

      this.UserId = userId;
    }

    // TODO: Validate username
    private void SetUsername(string username)
    {
      if (string.IsNullOrEmpty(username))
      {
        throw new DomainException(UserErrorCodes.EmptyUsername, "User name cannot be empty!.");
      }

      if (this.Username == username)
      {
        return;
      }

      this.Username = username;
    }

    // TODO: Validate email
    private void SetEmail(string email)
    {
      if (string.IsNullOrEmpty(email))
      {
        throw new DomainException(UserErrorCodes.EmptyEmail, "User email cannot be empty!.");
      }

      if (this.Email == email)
      {
        return;
      }

      this.Email = email;
    }
  }
}