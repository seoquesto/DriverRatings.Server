using System;

namespace src.DriverRatings.Server.Core.Models
{
  public class PlateComment : CommentBase
  {
    public int Note { get; protected set; }

    protected PlateComment()
    {
    }

    public PlateComment(CreatorInfo creatorInfo, string content, int note = 0)
      : this(Guid.NewGuid(), creatorInfo, content)
    {
    }

    public PlateComment(Guid commentId, CreatorInfo creatorInfo, string content, int note = 0)
    : base(commentId, creatorInfo, content)
    {
      this.Note = note;
    }
  }
}