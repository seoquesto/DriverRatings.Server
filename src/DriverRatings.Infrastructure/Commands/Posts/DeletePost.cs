using System;

namespace src.DriverRatings.Infrastructure.Commands.Posts
{
  public class DeletePost : AuthenticateCommandBase
  {
    public Guid PostId { get; set; }
  }
}