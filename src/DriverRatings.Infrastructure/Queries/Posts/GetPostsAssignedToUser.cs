using System.Collections.Generic;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Queries.Posts
{
  public class GetPostsAssignedToUser : IQuery<IEnumerable<PostDto>>
  {
    public string Username { get; set; }
  }
}