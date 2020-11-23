using System;

namespace src.DriverRatings.Server.Core.Models
{
  public class PostComment : CommentBase
  {
    protected PostComment()
    {
    }

    public PostComment(CreatorInfo creatorInfo, string content)
      : this(Guid.NewGuid(), creatorInfo, content)
    {
    }

    public PostComment(Guid commentId, CreatorInfo creatorInfo, string content)
    : base(commentId, creatorInfo, content)
    {
    }
  }
}