using System;
using src.DriverRatings.Core.Exceptions;

namespace src.DriverRatings.Core.Models
{
  public class User
  {
    public Guid UserId { get; protected set; }
    public string Username { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public string Salt { get; protected set; }
    public string Role { get; protected set; }

    protected User()
    {
    }

    public User(string username, string email, string password, string salt, string role = "user")
      : this(Guid.NewGuid(), username, email, password, salt, role)
    {
    }

    public User(Guid userId, string username, string email, string password, string salt, string role = "user")
    {
      this.SetUserId(userId);
      this.SetUsername(username);
      this.SetEmail(email);
      this.SetPassword(password);
      this.SetSalt(salt);
      this.SetRole(role);
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

    // TODO: Validate password
    private void SetPassword(string password)
    {
      if (string.IsNullOrEmpty(password))
      {
        throw new DomainException(UserErrorCodes.EmptyPassword, "User password cannot be empty!.");
      }

      if (this.Password == password)
      {
        return;
      }

      this.Password = password;
    }

    // TODO: Validate salt
    private void SetSalt(string salt)
    {
      if (string.IsNullOrEmpty(salt))
      {
        throw new DomainException(UserErrorCodes.EmptySalt, "User salt cannot be empty!.");
      }

      if (this.Salt == salt)
      {
        return;
      }

      this.Salt = salt;
    }

    // TODO: Invalid role
    private void SetRole(string role)
    {
      if (string.IsNullOrEmpty(role))
      {
        throw new DomainException(UserErrorCodes.EmptyRole, "User role cannot be empty!.");
      }

      if (this.Role == role)
      {
        return;
      }

      this.Role = role;
    }
  }
}