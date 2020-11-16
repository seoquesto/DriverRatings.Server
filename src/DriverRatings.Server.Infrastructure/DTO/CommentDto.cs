using System;
using src.DriverRatings.Server.Core.Models;

namespace src.DriverRatings.Server.Infrastructure.DTO
{
  public class CommentDto
  {
    public Guid CommentId { get; set; }
    public UserInfo UserInfo { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAd { get; set; }

  }
}