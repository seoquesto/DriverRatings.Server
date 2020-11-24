using System;
using src.DriverRatings.Server.Core.Exceptions;

namespace src.DriverRatings.Server.Core.Models
{
  public abstract class CommentBase
  {
    public Guid CommentId { get; protected set; }
    public CreatorInfo CreatorInfo { get; protected set; }
    public string Content { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    protected CommentBase()
    {
    }

    public CommentBase(CreatorInfo creatorInfo, string content)
      : this(Guid.NewGuid(), creatorInfo, content)
    {
    }

    public CommentBase(Guid commentId, CreatorInfo creatorInfo, string content)
    {
      this.CommentId = commentId;
      this.SetCreatorInfo(creatorInfo);
      this.SetContent(content);
      this.CreatedAt = DateTime.UtcNow;
    }

    private void SetCreatorInfo(CreatorInfo creatorInfo)
    {
      if (creatorInfo is null)
      {
        throw new InvalidAggregationException("Creator's information are required in a comment.");
      }

      if (this.CreatorInfo == creatorInfo)
      {
        return;
      }

      this.CreatorInfo = creatorInfo;
    }

    private void SetContent(string content)
    {
      var fixedContent = content?.Trim();
      if (string.IsNullOrEmpty(fixedContent))
      {
        throw new InvalidCommentContentException("Comment cannot be empty.");
      }


      if (this.Content == fixedContent)
      {
        return;
      }

      this.Content = fixedContent;
    }
  }
}