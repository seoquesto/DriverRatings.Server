using System;

namespace src.DriverRatings.Infrastructure.Commands.Posts
{
  public class CreatePost : AuthenticateCommandBase
  {
    public string Content { get; set; }
  }
}