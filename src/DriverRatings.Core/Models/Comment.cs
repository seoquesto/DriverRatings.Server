using System;

namespace src.DriverRatings.Core.Models
{
  public class Comment
  {
    public Guid Id { get; protected set; }
    public UserInfo UserInfo { get; protected set; }
    public string Content { get; protected set; }
    public DateTime CreatedAd { get; protected set; }

    protected Comment()
    {
    }

    public Comment(UserInfo userInfo, string content)
      : this(Guid.NewGuid(), userInfo, content)
    {
    }

    public Comment(Guid id, UserInfo userInfo, string content)
    {
      this.Id = id;
      this.UserInfo = userInfo;
      this.Content = content;
    }
  }
}