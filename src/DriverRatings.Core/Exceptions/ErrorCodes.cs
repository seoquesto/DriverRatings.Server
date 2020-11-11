namespace src.DriverRatings.Core.Exceptions
{
  public static class UserErrorCodes
  {
    public const string EmptyUserId = "empty_user_id";
    public const string EmptyUsername = "empty_user_name";
    public const string EmptyPassword = "empty_user_password";
    public const string EmptySalt = "empty_user_salt";
    public const string EmptyEmail = "empty_user_email";
    public const string EmptyRole = "empty_user_role";
  }

  public static class PostErrorCodes
  {
    public const string EmptyPostId = "empty_post_id";
    public const string EmptyUserInfo = "empty_post_user_info";
    public const string EmptyContent = "empty_post_content";
  }

  public static class CommentErrorCodes
  {
    public const string EmptyCommentId = "empty_comment_id";
    public const string EmptyCommentUserInfo = "empty_comment_user_info";
    public const string EmptyCommentContent = "empty_comment_content";
  }

  public static class RefreshTokenErrorCodes
  {
    public const string EmptyRefreshTokenUserId = "empty_refresh_token_user_id";
    public const string EmptyRefreshToken = "empty_refresh_token";
  }
}