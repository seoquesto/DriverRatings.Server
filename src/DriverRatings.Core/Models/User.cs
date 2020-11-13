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
      if (userId == Guid.Empty)
      {
        throw new InvalidIdException("Invalid user id.");
      }

      if (this.UserId == userId)
      {
        return;
      }

      this.UserId = userId;
    }

    private void SetUsername(string username)
    {
      if (string.IsNullOrEmpty(username))
      {
        throw new InvalidCredentialsException("Username cannot be empty.");
      }

      if (this.Username == username)
      {
        return;
      }

      this.Username = username;
    }

    private void SetEmail(string email)
    {
      if (string.IsNullOrEmpty(email))
      {
        throw new InvalidCredentialsException("Email cannot be empty.");
      }

      if (this.Email == email)
      {
        return;
      }

      this.Email = email;
    }

    private void SetPassword(string password)
    {
      if (string.IsNullOrEmpty(password))
      {
        throw new InvalidCredentialsException();
      }

      if (this.Password == password)
      {
        return;
      }

      this.Password = password;
    }

    private void SetSalt(string salt)
    {
      if (string.IsNullOrEmpty(salt))
      {
        throw new InvalidCredentialsException();
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
        throw new InvalidRoleException();
      }

      if (this.Role == role)
      {
        return;
      }

      this.Role = role;
    }
  }
}