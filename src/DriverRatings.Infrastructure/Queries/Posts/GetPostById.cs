using System;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Queries.Posts
{
  public class GetPostById : IQuery<PostDto>
  {
    public Guid PostId { get; set; }
  }
}