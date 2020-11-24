namespace src.DriverRatings.Server.Infrastructure.Commands.Posts
{
  public class CreatePost : AuthenticateCommandBase
  {
    public string Content { get; set; }
    public string PlateIdentifier { get; set; }
    public string PlateNumber { get; set; }
  }
}