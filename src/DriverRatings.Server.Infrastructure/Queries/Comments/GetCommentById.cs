using System;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Queries.Comments
{
  public class GetCommentById : IQuery<PostCommentDto>
  {
    public Guid PostId { get; set; }
    public Guid CommentId { get; set; }
  }
}