using System;
using System.Threading.Tasks;
using AutoMapper;
using NLog;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Core.Repositories;
using src.DriverRatings.Server.Infrastructure.Services.Interfaces;

namespace src.DriverRatings.Server.Infrastructure.Services
{
  public class PlateCommentsManager : IPlateCommentsManager
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

    public async Task AddPlateCommentAsync(Plate plate, User user, string comment, int note)
    {
      // TODO: Validation
      var plateDetails = await this._platesDetailsRepository.GetAsync(x => x.Identifier == identifier && x.Number == number);
      if (!(plateDetails is null))
      {
        return;
      }

      var user = await this._usersRepository.GetAsync(x => x.UserId == userId);
      var creator = new CreatorInfo(userId, user.Username);
      var plateComment = new PlateComment(creator, comment, note);
      plateDetails.AddComment(plateComment);

      await this._platesDetailsRepository.UpdateAsync(plateDetails, x => x.Identifier == identifier && x.Number == number);
    }
  }
}