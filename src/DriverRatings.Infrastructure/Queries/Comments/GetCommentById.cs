using System;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Queries.Comments
{
  public class GetCommentById : IQuery<CommentDto>
  {
    public Guid PostId { get; set; }
    public Guid CommentId { get; set; }
  }
}