using System;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services.Interfaces
{
  public interface IJwtHandler
  {
    JwtDto CreateToken(Guid userId, string role);
  }
}