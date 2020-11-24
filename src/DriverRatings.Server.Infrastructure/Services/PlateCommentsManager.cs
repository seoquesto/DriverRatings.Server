using System;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using src.DriverRatings.Server.Core.Exceptions;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Core.Repositories;
using src.DriverRatings.Server.Infrastructure.Exceptions;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Services
{
  public class PlateCommentsManager : IPlateCommentsManager, IService
  {
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly IPlatesDetailsRepository _platesDetailsRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;

    public PlateCommentsManager(IUsersRepository usersRepository, IPlatesDetailsRepository platesDetailsRepository, IMapper mapper)
    {
      this._usersRepository = usersRepository;
      this._platesDetailsRepository = platesDetailsRepository;
      this._mapper = mapper;
    }

    public async Task AddPlateCommentAsync(string plateIdentifier, string plateNumber, Guid userId, string comment, int note)
    {
      var modifiedIdentifier = plateIdentifier?.Trim().ToUpperInvariant();
      var modifiedNumber = plateNumber?.Trim().ToUpperInvariant();

      if (string.IsNullOrEmpty(modifiedIdentifier))
      {
        throw new InvalidPlateIdentifierException(modifiedIdentifier);
      }

      if (string.IsNullOrEmpty(modifiedNumber))
      {
        throw new InvalidPlateNumberException(modifiedNumber);
      }

      var plateDetails = await this._platesDetailsRepository.GetAsync(x => x.Identifier == plateIdentifier && x.Number == plateNumber);
      if (plateDetails is null)
      {
        throw new PlateNotFoundException(modifiedIdentifier, modifiedNumber);
      }

      var user = await this._usersRepository.GetAsync(x => x.UserId == userId);

      if (user is null)
      {
        throw new UserNotFoundException($"User with id: {userId} was not found.");
      }

      var creator = new CreatorInfo(userId, user.Username);
      var plateComment = new PlateComment(creator, comment, note);
      plateDetails.AddComment(plateComment);

      await this._platesDetailsRepository.UpdateAsync(plateDetails, x => x.Identifier == plateIdentifier && x.Number == plateNumber);
    }
  }
}