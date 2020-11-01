namespace src.DriverRatings.Core.Models
{
  public static class UserErrorCodes
  {
    public static string InvalidUserId = "invalid_user_id";
    public static string InvalidUsername = "invalid_username";
    public static string InvalidPassword = "invalid_password";
    public static string InvalidSalt = "invalid_salt";
    public static string InvalidEmail = "invalid_email";
    public static string InvalidRole = "invalid_role";
  }

  public static class PostErrorCodes
  {
    public static string InvalidPostId = "invalid_post_id";
    public static string InvalidPostUserInfo = "invalid_post_user_info";
    public static string InvalidPostContent = "invalid_post_content";
  }
}