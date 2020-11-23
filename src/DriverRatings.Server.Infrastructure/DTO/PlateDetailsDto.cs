using System.Collections.Generic;

namespace src.DriverRatings.Server.Infrastructure.DTO
{
  public class PlateDetailsDto
  {
    public IEnumerable<PlateCommentDto> Comments { get; set; }
  }
}