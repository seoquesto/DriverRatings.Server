using System;

namespace src.DriverRatings.Infrastructure.Commands.Comments
{
  public class CreateComment : AuthenticateCommandBase
  {
    public Guid PostId { get; set; }
    public string Content { get; set; }
  }
}