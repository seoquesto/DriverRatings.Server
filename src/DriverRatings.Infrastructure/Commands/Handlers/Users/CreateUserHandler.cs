using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Commands.Users;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Commands.Handlers.Users
{
  public class CreateUserHandler : ICommandHandler<CreateUser, UserDto>
  {
    private readonly IUsersService _usersService;

    public CreateUserHandler(IUsersService usersService)
      => _usersService = usersService;

    public async Task<UserDto> HandleAsync(CreateUser command)
    {
      var userId = Guid.NewGuid();
      await this._usersService.RegisterAsync(userId, command.Username, command.Email, command.Password);
      return new UserDto { Email = command.Email, UserId = userId, Username = command.Username };
    }
  }
}