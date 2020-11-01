namespace src.DriverRatings.Core.Models
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
    public const string InvalidCommentId = "invalid_comment_id";
    public const string UserInfoRequired = "comment_user_info_required";
    public const string InvalidCommentContent = "invalid_comment_content";
  }
}