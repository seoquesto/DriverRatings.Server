using System.Threading.Tasks;
using AutoMapper;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Queries.Users;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Queries.Handlers.Users
{
  public class GetUserByNameHandler : IQueryHandler<GetUserByName, UserDto>
  {
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;

    public GetUserByNameHandler(IUsersService usersService, IMapper mapper)
      => (_usersService, _mapper) = (usersService, mapper);

    public async Task<UserDto> HandleAsync(GetUserByName query)
    {
      var user = await this._usersService.GetByUsernameAsync(query.Username);
      return this._mapper.Map<UserDto>(user);
    }
  }
}