using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Users;
using src.DriverRatings.Infrastructure.Services;

namespace src.DriverRatings.Infrastructure.Handlers.Users
{
  public class CreateUserHandler : ICommandHandler<CreateUser>
  {
    private readonly IUsersService _usersService;
    private readonly IHandler _handler;
    

    public CreateUserHandler(IUsersService usersService, IHandler handler)
    {
      this._usersService = usersService;
      this._handler = handler;
    }

    public async Task HandleAsync(CreateUser command)
    {
      
      var userId = Guid.NewGuid();
      await _handler.Run(async () => await this._usersService.RegisterAsync(userId, command.Username, command.Email, command.Password)).ExecuteAsync();
    }
  }
}