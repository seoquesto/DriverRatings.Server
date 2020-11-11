using System.Threading.Tasks;

namespace src.DriverRatings.Infrastructure.Queries
{
  public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
  {
    Task<TResult> HandleAsync(TQuery query);
  }
}