using System;

namespace src.DriverRatings.Server.Infrastructure.Exceptions
{
  public class PostNotFoundException : AppException
  {
    public override string Code { get; } = "post_not_found";

    public PostNotFoundException(Guid postId) : base($"Post not found: {postId.ToString()}.")
    {
    }
  }
}