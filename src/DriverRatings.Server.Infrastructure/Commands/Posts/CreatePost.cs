namespace src.DriverRatings.Server.Infrastructure.Commands.Posts
{
  public class CreatePost : AuthenticateCommandBase
  {
    public string Content { get; set; }
  }
}