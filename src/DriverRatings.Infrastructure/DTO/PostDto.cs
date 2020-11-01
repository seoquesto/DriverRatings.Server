using System;
using System.Collections.Generic;

namespace src.DriverRatings.Infrastructure.DTO
{
  public class PostDto
  {
    public Guid PostId { get; set; }
    public UserInfoDto UserInfo { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<CommentDto> Comments { get; set; }
  }
}