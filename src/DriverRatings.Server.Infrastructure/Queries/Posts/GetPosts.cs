using System.Collections.Generic;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Queries.Posts
{
  public class GetPosts : IQuery<IEnumerable<PostDto>>
  {
    public string PlateIdentifier { get; set; }
    public string PlateNumber { get; set; }
  }
}