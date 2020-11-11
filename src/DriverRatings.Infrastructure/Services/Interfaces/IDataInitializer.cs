using System.Threading.Tasks;

namespace src.DriverRatings.Infrastructure.Services.Interfaces
{
  public interface IDataInitializer
  {
    Task SeedAsync();
  }
}