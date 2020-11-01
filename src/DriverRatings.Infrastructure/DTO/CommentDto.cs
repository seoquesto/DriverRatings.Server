using System;
using src.DriverRatings.Core.Models;

namespace src.DriverRatings.Infrastructure.DTO
{
  public class CommentDto
  {
    public Guid Id { get; set; }
    public UserInfo UserInfo { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAd { get; set; }

  }
}