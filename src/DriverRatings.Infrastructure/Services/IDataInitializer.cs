using System.Threading.Tasks;

namespace src.DriverRatings.Infrastructure.Services
{
    public interface IDataInitializer
    {
        Task SeedAsync();
    }
}