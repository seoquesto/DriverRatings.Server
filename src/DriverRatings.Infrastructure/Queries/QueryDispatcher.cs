using System.Threading.Tasks;
using Autofac;

namespace src.DriverRatings.Infrastructure.Queries
{
  public class QueryDispatcher : IQueryDispatcher
  {
    private readonly IComponentContext _componentContext;

    public QueryDispatcher(IComponentContext componentContext)
    {
      this._componentContext = componentContext;
    }

    public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>
    {

      return await this._componentContext.Resolve<IQueryHandler<TQuery, TResult>>().HandleAsync(query);
    }
  }
}