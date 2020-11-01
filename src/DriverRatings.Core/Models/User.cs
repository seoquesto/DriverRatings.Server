using System;

namespace src.DriverRatings.Core.Models
{
  public class User
  {
    public Guid Id { get; protected set; }
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

    public User(Guid id, string username, string email, string password, string salt, string role = "user")
    {
      this.SetId(id);
      this.SetUsername(username);
      this.SetEmail(email);
      this.SetPassword(password);
      this.SetSalt(salt);
      this.SetRole(role);
    }

    private void SetId(Guid id)
    {
      if (id == null)
      {
        throw new DomainException(UserErrorCodes.InvalidUserId, "User id cannot be empty!.");
      }

      if (this.Id == id)
      {
        return;
      }

      this.Id = id;
    }

    // TODO: Validate username
    private void SetUsername(string username)
    {
      if (string.IsNullOrEmpty(username))
      {
        throw new DomainException(UserErrorCodes.InvalidUsername, "User name cannot be empty!.");
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
        throw new DomainException(UserErrorCodes.InvalidEmail, "User email cannot be empty!.");
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
        throw new DomainException(UserErrorCodes.InvalidPassword, "User password cannot be empty!.");
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
        throw new DomainException(UserErrorCodes.InvalidSalt, "User salt cannot be empty!.");
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
        throw new DomainException(UserErrorCodes.InvalidRole, "User role cannot be empty!.");
      }

      if (this.Role == role)
      {
        return;
      }

      this.Role = role;
    }
  }
}