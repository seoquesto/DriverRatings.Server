using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Queries.Users
{
    public class GetUserByEmail : IQuery<UserDto>
    {
        public string Email { get; set; }
    }
}