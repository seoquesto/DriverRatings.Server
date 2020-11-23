using System;
using System.Threading.Tasks;
using src.DriverRatings.Server.Infrastructure.DTO;

namespace src.DriverRatings.Server.Infrastructure.Services.Interfaces
{
  public interface IPlatesDetailsService
  {
    Task AddPlateAsync(string identifier, string number);
    Task<PlateDetailsDto> GetAsync(string identifier, string number);
  }
}