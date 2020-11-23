using System;

namespace src.DriverRatings.Server.Infrastructure.DTO
{
  public class CommentBaseDto
  {
    public Guid CommentId { get; set; }
    public CreatorInfoDto CreatorInfo { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}