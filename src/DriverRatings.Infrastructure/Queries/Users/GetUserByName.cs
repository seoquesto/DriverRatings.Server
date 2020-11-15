using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Queries.Users
{
  public class GetUserByName : IQuery<UserDto>
  {
    public string Username { get; set; }
  }
}