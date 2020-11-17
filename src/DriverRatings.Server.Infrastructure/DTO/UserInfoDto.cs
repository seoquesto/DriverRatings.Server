using System;

namespace src.DriverRatings.Server.Infrastructure.DTO
{
  public class UserInfoDto
  {
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
  }
}