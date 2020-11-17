using System.Collections.Generic;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Queries.Posts
{
  public class GetPostsAssignedToUser : IQuery<IEnumerable<PostDto>>
  {
    public string Username { get; set; }
  }
}