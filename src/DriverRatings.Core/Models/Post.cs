using System;
using System.Collections.Generic;

namespace src.DriverRatings.Core.Models
{
  public class Post
  {
    private ISet<Comment> _comments = new HashSet<Comment>();

    public Guid Id { get; protected set; }
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

    public Post(Guid id, UserInfo userInfo, string content)
    {
      this.SetId(id);
      this.SetUserInfo(userInfo);
      this.SetContent(content);
      CreatedAt = DateTime.UtcNow;
    }

    private void SetId(Guid id)
    {
      if (id == null)
      {
        throw new DomainException(PostErrorCodes.InvalidPostId, "Post id cannot be empty!.");
      }

      if (this.Id == id)
      {
        return;
      }

      this.Id = id;
    }

    private void SetUserInfo(UserInfo userInfo)
    {
      if (userInfo == null)
      {
        throw new DomainException(PostErrorCodes.InvalidPostUserInfo, "Post user info cannot be empty!.");
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
        throw new DomainException(PostErrorCodes.InvalidPostContent, "Post content id cannot be empty!.");
      }

      if (this.Content == content)
      {
        return;
      }

      this.Content = content;
    }
  }
}