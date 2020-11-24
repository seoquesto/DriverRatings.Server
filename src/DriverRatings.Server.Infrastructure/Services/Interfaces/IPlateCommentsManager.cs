using System;
using System.Threading.Tasks;

namespace src.DriverRatings.Server.Infrastructure.Services.Interfaces
{
  public interface IPlateCommentsManager
  {
    Task AddPlateCommentAsync(string plateIdentifier, string plateNumber, Guid userId, string comment, int note);
  }
}