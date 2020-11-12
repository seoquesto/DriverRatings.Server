using System.Threading.Tasks;

namespace src.DriverRatings.Infrastructure.Queries
{
  public interface IQueryDispatcher
  {
    Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>;
  }
}