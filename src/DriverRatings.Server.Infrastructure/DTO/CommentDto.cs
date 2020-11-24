using System;

namespace src.DriverRatings.Server.Infrastructure.DTO
{
  public class CommentDto
  {
    public Guid CommentId { get; set; }
    public CreatorInfoDto UserInfo { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAd { get; set; }

  }
}