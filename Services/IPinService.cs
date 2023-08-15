using ExploreCity.Models;

namespace ExploreCity.Services
{
    public interface IPinService
    {
        Task<List<PinModel>> GetPinsAsync();
        Task<int> InsertPinAsync(PinModel pinModel);
        Task<int> DeleteAllPinsAsync();
        Task<int> UpdatePinAsync(PinModel pinModel);
        Task<PinModel> GetSpecifiedPin(double longitud);
    }
}
