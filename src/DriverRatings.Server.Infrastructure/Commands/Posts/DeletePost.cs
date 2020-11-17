using System;

namespace src.DriverRatings.Server.Infrastructure.Commands.Posts
{
  public class DeletePost : AuthenticateCommandBase
  {
    public Guid PostId { get; set; }
  }
}