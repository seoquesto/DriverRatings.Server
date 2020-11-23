using System.Threading.Tasks;
using AutoMapper;
using NLog;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Core.Repositories;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Services
{
  public class PlatesDetailsService : IPlatesDetailsService
  {
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IPlatesDetailsRepository _platesDetailsRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public PlatesDetailsService(IUsersRepository usersRepository, IPlatesDetailsRepository platesDetailsRepository, IMapper mapper)
    {
      this._usersRepository = usersRepository;
      this._platesDetailsRepository = platesDetailsRepository;
      this._mapper = mapper;
    }

    public async Task AddPlateAsync(string identifier, string number)
    {
      // TODO: Improve validation
      var plateDetails = await this._platesDetailsRepository.GetAsync(x => x.Identifier == identifier && x.Number == number);
      if (!(plateDetails is null))
      {
        return;
      }
      plateDetails = new PlateDetails(identifier, number);
      await this._platesDetailsRepository.AddAsync(plateDetails);
    }

    public async Task<PlateDetailsDto> GetAsync(string identifier, string number)
    {
      // TODO: Improve validation
      var modifiedIdentifier = identifier?.Trim().ToUpperInvariant();
      var modifiedNumber = number?.Trim().ToUpperInvariant();
      var plateDetails = await this._platesDetailsRepository.GetAsync(x => x.Identifier == modifiedIdentifier && x.Number == modifiedNumber);

      return this._mapper.Map<PlateDetailsDto>(plateDetails);
    }
  }
}