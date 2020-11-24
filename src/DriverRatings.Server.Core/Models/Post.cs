using System;
using System.Collections.Generic;
using System.Linq;
using src.DriverRatings.Server.Core.Exceptions;

namespace src.DriverRatings.Server.Core.Models
{
  public class Post
  {
    private ISet<PostComment> _comments = new HashSet<PostComment>();

    public Guid PostId { get; protected set; }
    public CreatorInfo CreatorInfo { get; protected set; }
    public Plate Plate { get; protected set; }
    public string Content { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public IEnumerable<PostComment> Comments
    {
      get => this._comments;
      private set => this._comments = new HashSet<PostComment>(value);
    }

    protected Post()
    {
    }

    public Post(CreatorInfo creatorInfo, Plate plate, string content)
      : this(Guid.NewGuid(), creatorInfo, plate, content)
    {
    }

    public Post(Guid postId, CreatorInfo creatorInfo, Plate plate, string content)
    {
      this.PostId = postId;
      this.SetCreatorInfo(creatorInfo);
      this.SetPlate(plate);
      this.SetContent(content);
      CreatedAt = DateTime.UtcNow;
    }

    private void SetPostId(Guid postId)
    {
      if (postId == Guid.Empty)
      {
        throw new InvalidIdException("Invalid post id.");
      }

      if (this.PostId == postId)
      {
        return;
      }

      this.PostId = postId;
    }

    private void SetCreatorInfo(CreatorInfo creatorInfo)
    {
      if (creatorInfo is null)
      {
        throw new InvalidAggregationException("Creator's information are required in a post.");
      }

      if (this.CreatorInfo == creatorInfo)
      {
        return;
      }

      this.CreatorInfo = creatorInfo;
    }

    private void SetPlate(Plate plate)
    {
      if (plate is null)
      {
        throw new InvalidAggregationException("Plate's information are required in a post.");
      }

      if (this.Plate == plate)
      {
        return;
      }

      this.Plate = plate;
    }

    private void SetContent(string content)
    {
      var fixedContent = content?.Trim();
      if (string.IsNullOrEmpty(fixedContent))
      {
        throw new InvalidCommentContentException("Post cannot be empty.");
      }

      if (this.Content == fixedContent)
      {
        return;
      }

      this.Content = fixedContent;
    }

    public void AddComment(PostComment comment)
    {
      if (Comments.Any(x => x.CommentId == comment.CommentId))
      {
        return;
      }

      _comments.Add(comment);
    }
  }
}