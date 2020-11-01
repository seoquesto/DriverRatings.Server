using System;
using src.DriverRatings.Core.Exceptions;

namespace src.DriverRatings.Core.Models
{
  public class Comment
  {
    public Guid CommentId { get; protected set; }
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

    public Comment(Guid commentId, UserInfo userInfo, string content)
    {
      this.SetCommentId(commentId);
      this.SetUserInfo(userInfo);
      this.SetContent(content);
      this.CreatedAd = DateTime.UtcNow;
    }

    private void SetCommentId(Guid commentId)
    {
      if (commentId == null)
      {
        throw new DomainException(CommentErrorCodes.InvalidCommentId, "Comment id cannot be empty!.");
      }

      if (this.CommentId == commentId)
      {
        return;
      }

      this.CommentId = commentId;
    }

    private void SetUserInfo(UserInfo userInfo)
    {
      if (userInfo == null)
      {
        throw new DomainException(CommentErrorCodes.UserInfoRequired, "User info in comment is required!.");
      }

      if (this.UserInfo == userInfo)
      {
        return;
      }

      this.UserInfo = userInfo;
    }

    private void SetContent(string content)
    {
      if (string.IsNullOrEmpty(content))
      {
        throw new DomainException(CommentErrorCodes.InvalidCommentContent, "Comment content id cannot be empty!.");
      }

      if (this.Content == content)
      {
        return;
      }

      this.Content = content;
    }
  }
}