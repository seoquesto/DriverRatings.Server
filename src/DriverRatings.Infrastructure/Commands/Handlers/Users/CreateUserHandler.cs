using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Users;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Commands.Handlers.Users
{
  public class CreateUserHandler : ICommandHandler<CreateUser>
  {
    private readonly IUsersService _usersService;

    public CreateUserHandler(IUsersService usersService)
      => _usersService = usersService;

    public async Task HandleAsync(CreateUser command)
      => await this._usersService.RegisterAsync(Guid.NewGuid(), command.Username, command.Email, command.Password);
  }
}