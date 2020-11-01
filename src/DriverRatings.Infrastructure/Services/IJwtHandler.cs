using System;
using src.DriverRatings.Infrastructure.DTO;

namespace src.DriverRatings.Infrastructure.Services
{
  public interface IJwtHandler
  {
    JwtDto CreateToken(Guid userId, string role);
  }
}