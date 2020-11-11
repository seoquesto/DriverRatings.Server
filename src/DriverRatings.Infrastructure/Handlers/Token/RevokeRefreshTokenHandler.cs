using System.Threading.Tasks;
using src.DriverRatings.Infrastructure.Commands;
using src.DriverRatings.Infrastructure.Commands.Token;
using src.DriverRatings.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Infrastructure.Handlers.Token
{
  public class RevokeRefreshTokenHandler : ICommandHandler<RevokeRefreshToken>
  {
    private readonly ITokenManager _tokenManager;

    public RevokeRefreshTokenHandler(ITokenManager tokenManager)
    {
      this._tokenManager = tokenManager;
    }

    public async Task HandleAsync(RevokeRefreshToken command)
    {
      await this._tokenManager.RevokeRefreshToken(command.RefreshToken);
    }
  }
}