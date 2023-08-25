using ExploreCity.Models;
using SQLite;

namespace ExploreCity.Services
{
    public class UserService : IUserService
    {
        static SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExploreCityUsers.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<UserModel>();
        }

        public async Task<List<UserModel>> GetUser()
        {
            await Init();
            var response = await db.Table<UserModel>().ToListAsync();

            return response;
        }

        public async Task<int> InsertUser(UserModel userModel)
        {
            await Init();

            var response = await db.InsertAsync(userModel);
            return response;
        }
    }
}
