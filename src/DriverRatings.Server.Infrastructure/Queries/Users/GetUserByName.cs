using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Queries.Users
{
  public class GetUserByName : IQuery<UserDto>
  {
    public string Username { get; set; }
  }
}