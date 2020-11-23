using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using src.DriverRatings.Server.Core.Models;

namespace src.DriverRatings.Server.Core.Repositories
{
  public interface IPlatesDetailsRepository
  {
    Task AddAsync(PlateDetails plateDetails);
    Task<PlateDetails> GetAsync(Expression<Func<PlateDetails, bool>> predicate);
    Task UpdateAsync(PlateDetails plate, Expression<Func<PlateDetails, bool>> predicate);
    Task DeleteAsync(Expression<Func<PlateDetails, bool>> predicate);
  }
}
