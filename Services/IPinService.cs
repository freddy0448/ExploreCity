using ExploreCity.Models;

namespace ExploreCity.Services
{
    public interface IPinService
    {
        Task<List<PinModel>> GetPinsAsync();
        Task<int> InsertPinAsync(PinModel pinModel);
        Task<int> DeleteAllPinsAsync();
    }
}
