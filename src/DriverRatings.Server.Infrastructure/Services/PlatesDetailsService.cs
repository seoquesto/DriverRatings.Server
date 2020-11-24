using System.Threading.Tasks;
using AutoMapper;
using NLog;
using src.DriverRatings.Server.Core.Exceptions;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Core.Repositories;
using src.DriverRatings.Server.Infrastructure.DTO;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Services
{
  public class PlatesDetailsService : IPlatesDetailsService, IService
  {
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IPlatesDetailsRepository _platesDetailsRepository;
    private readonly IMapper _mapper;

    public PlatesDetailsService(IPlatesDetailsRepository platesDetailsRepository, IMapper mapper)
    {
      this._platesDetailsRepository = platesDetailsRepository;
      this._mapper = mapper;
    }

    public async Task AddPlateAsync(string identifier, string number)
    {
      var plate = await this.GetAsync(identifier, number);
      if (plate is { })
      {
        // Do nothing.
        return;
      }
      var plateDetails = new PlateDetails(identifier, number);
      await this._platesDetailsRepository.AddAsync(plateDetails);
    }

    public async Task<PlateDetailsDto> GetAsync(string identifier, string number)
    {
      var modifiedIdentifier = identifier?.Trim().ToUpperInvariant();
      var modifiedNumber = number?.Trim().ToUpperInvariant();

      if (string.IsNullOrEmpty(modifiedIdentifier))
      {
        throw new InvalidPlateIdentifierException(modifiedIdentifier);
      }

      if (string.IsNullOrEmpty(modifiedNumber))
      {
        throw new InvalidPlateNumberException(modifiedNumber);
      }

      var plateDetails = await this._platesDetailsRepository.GetAsync(x => x.Identifier == modifiedIdentifier && x.Number == modifiedNumber);

      return this._mapper.Map<PlateDetailsDto>(plateDetails);
    }
  }
}