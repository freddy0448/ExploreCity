using ExploreCity.Models;

namespace ExploreCity.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUser();
        Task<int> InsertUser(UserModel userModel);
    }
}
