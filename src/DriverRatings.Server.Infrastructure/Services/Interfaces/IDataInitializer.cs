using System.Threading.Tasks;

namespace src.DriverRatings.Server.Infrastructure.Services.Interfaces
{
  public interface IDataInitializer
  {
    Task SeedAsync();
  }
}