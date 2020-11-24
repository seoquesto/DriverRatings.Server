using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using src.DriverRatings.Server.Core.Models;
using src.DriverRatings.Server.Core.Repositories;

namespace src.DriverRatings.Server.Infrastructure.Repositories
{
  public class PlatesDetailsRepository : IPlatesDetailsRepository, IMongoRepository
  {
    private const string CollectionName = "platesDetails";
    private readonly IMongoCollection<PlateDetails> _platesDetails;

    public PlatesDetailsRepository(IMongoDatabase mongoDatabase)
    {
      this._platesDetails = mongoDatabase.GetCollection<PlateDetails>(CollectionName);
    }

    public async Task AddAsync(PlateDetails plateDetails)
      => await this._platesDetails.InsertOneAsync(plateDetails);

    public async Task<PlateDetails> GetAsync(Expression<Func<PlateDetails, bool>> predicate)
      => await this._platesDetails.Find(predicate).SingleOrDefaultAsync();

    public async Task DeleteAsync(Expression<Func<PlateDetails, bool>> predicate)
      => await this._platesDetails.DeleteOneAsync(predicate);

    public async Task UpdateAsync(PlateDetails plateDetails, Expression<Func<PlateDetails, bool>> predicate)
      => await this._platesDetails.ReplaceOneAsync(predicate, plateDetails);

  }
}