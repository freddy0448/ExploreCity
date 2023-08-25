using ExploreCity.Models;
using SQLite;

namespace ExploreCity.Services
{
    public class PinService : IPinService
    {
        private SQLiteAsyncConnection db;

        async Task Init()
        {
            if (db != null)
                return;

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "ExploreCityPins.db");
            db = new SQLiteAsyncConnection(databasePath);

            await db.CreateTableAsync<PinModel>();
        }

        public async Task<int> InsertPinAsync(PinModel pinModel)
        {
            await Init();

            var response = await db.InsertAsync(pinModel);
            return response;
        }

        public async Task<List<PinModel>> GetPinsAsync()
        {
            await Init();

            var response = await db.Table<PinModel>().ToListAsync();
            return response;
        }

        public async Task<int> DeleteAllPinsAsync()
        {
            await Init();

            var response = await db.DeleteAllAsync<PinModel>();
            return response;
        }

        public async Task<int> UpdatePinAsync(PinModel pinModel)
        {
            await Init();
            return await db.UpdateAsync(pinModel);
        }

        public  Task<PinModel> GetSpecifiedPin(string id)
        {
            Init();

            return  db.FindAsync<PinModel>(id);
        }

        public async Task<PinModel> GetSpecifiedPinByDesc(string labelDescription)
        {
            await Init();
            return await db.FindWithQueryAsync<PinModel>($"SELECT * FROM PinModel WHERE LabelDescription = '{labelDescription}'"); 
        }


        public async Task<int> DeletePinAsync(PinModel pinModel)
        {
            await Init();

            return await db.DeleteAsync(pinModel);
        }

    }
}