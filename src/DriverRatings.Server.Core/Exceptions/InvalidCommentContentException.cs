namespace src.DriverRatings.Server.Core.Exceptions
{
  public class InvalidCommentContentException : DomainException
  {
    public override string Code { get; } = "invalid_comment_content";

    public InvalidCommentContentException(string message) : base(message)
    {
    }
  }
}