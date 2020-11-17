using System;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Services.Interfaces
{
  public interface IJwtHandler
  {
    JwtDto CreateToken(Guid userId, string role);
  }
}