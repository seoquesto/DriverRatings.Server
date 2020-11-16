using System;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Queries.Posts
{
  public class GetPostById : IQuery<PostDto>
  {
    public Guid PostId { get; set; }
  }
}