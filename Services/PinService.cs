using ExploreCity.Models;
using SQLite;

namespace ExploreCity.Services
{
    public class PinService : IPinService
    {
        private SQLiteAsyncConnection db;

        async void Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExploreCityPins.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<PinModel>();
        }

        public async Task<int> InsertPinAsync(PinModel pinModel)
        {
            Init();

            var response = await db.InsertAsync(pinModel);
            return response;
        }

        public async Task<List<PinModel>> GetPinsAsync()
        {
            Init();

            var response = await db.Table<PinModel>().ToListAsync();
            return response;
        }

        public async Task<int> DeleteAllPinsAsync()
        {
            Init();

            var response = await db.DeleteAllAsync<PinModel>();
            return response;
        }

        public async Task<int> UpdatePinAsync(PinModel pinModel)
        {
            Init();
            return await db.UpdateAsync(pinModel);
        }

    }
}