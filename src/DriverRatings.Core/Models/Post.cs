using System;
using System.Collections.Generic;
using src.DriverRatings.Core.Exceptions;

namespace src.DriverRatings.Core.Models
{
  public class Post
  {
    private ISet<Comment> _comments = new HashSet<Comment>();

    public Guid PostId { get; protected set; }
    public UserInfo UserInfo { get; protected set; }
    public string Content { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public IEnumerable<Comment> Comments
    {
      get => this._comments;
    }

    protected Post()
    {
    }

    public Post(UserInfo userInfo, string content)
      : this(Guid.NewGuid(), userInfo, content)
    {
    }

    public Post(Guid postId, UserInfo userInfo, string content)
    {
      this.SetPostId(postId);
      this.SetUserInfo(userInfo);
      this.SetContent(content);
      CreatedAt = DateTime.UtcNow;
    }

    private void SetPostId(Guid postId)
    {
      if (postId == null)
      {
        throw new DomainException(PostErrorCodes.EmptyPostId, "Post id cannot be empty!.");
      }

      if (this.PostId == postId)
      {
        return;
      }

      this.PostId = postId;
    }

    private void SetUserInfo(UserInfo userInfo)
    {
      if (userInfo is null)
      {
        throw new DomainException(PostErrorCodes.EmptyUserInfo, "Post user info cannot be empty!.");
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
        throw new DomainException(PostErrorCodes.EmptyContent, "Post content cannot be empty!.");
      }

      if (this.Content == content)
      {
        return;
      }

      this.Content = content;
    }
  }
}