using System.Threading.Tasks;
using src.DriverRatings.Server.Core.Models;

namespace src.DriverRatings.Server.Infrastructure.Services.Interfaces
{
  public interface IPlateCommentsManager
  {
    Task AddPlateCommentAsync(Plate plate, User user, string comment, int note);
  }
}