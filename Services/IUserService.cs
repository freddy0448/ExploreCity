using ExploreCity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExploreCity.Services
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUser();
        Task<int> AddUser(UserModel userModel);
    }
}
