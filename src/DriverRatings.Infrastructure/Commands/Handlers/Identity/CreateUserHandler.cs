using System;
using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Commands.Identity;
using src.DriverRatings.Infrastructure.DTO;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Commands.Handlers.Identity
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