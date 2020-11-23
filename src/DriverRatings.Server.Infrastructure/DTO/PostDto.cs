using System;
using System.Collections.Generic;

namespace src.DriverRatings.Server.Infrastructure.DTO
{
  public class PostDto
  {
    public Guid PostId { get; set; }
    public CreatorInfoDto CreatorInfo { get; set; }
    public PlateDto Plate { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public IEnumerable<CommentDto> Comments { get; set; }
  }
}