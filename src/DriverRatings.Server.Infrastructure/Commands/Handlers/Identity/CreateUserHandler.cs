using System;
using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.Commands.Identity;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Commands.Handlers.Identity
{
  public class CreateUserHandler : ICommandHandler<CreateUser, UserDto>
  {
    private readonly IIdentityService _identityService;

    public CreateUserHandler(IIdentityService identityService)
      => (_identityService) = (identityService);

    public async Task<UserDto> HandleAsync(CreateUser command)
    {
      var userId = Guid.NewGuid();
      await this._identityService.RegisterAsync(userId, command.Username, command.Email, command.Password, command.Role);
      return new UserDto { Email = command.Email, UserId = userId, Username = command.Username };
    }
  }
}