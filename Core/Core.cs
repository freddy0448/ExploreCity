using ExploreCity.Models;
using ExploreCity.Views;

namespace ExploreCity.Core
{
    public static class Core
    {
        public static async Task GoToDetailsWithDataAsync(PinModel pinModel)
        {
            var varParam = new Dictionary<string, object>();
            varParam.Add("PinData", pinModel);
            await Shell.Current.GoToAsync(nameof(DetailsPage), varParam);
        }
        public static void GoToDetailsWithData(PinModel pinModel)
        {
            var varParam = new Dictionary<string, object>();
            varParam.Add("PinData", pinModel);
            Shell.Current.GoToAsync(nameof(DetailsPage), varParam);
        }
        public async static Task GoToPageAsync(string pageName)
        {
            await Shell.Current.GoToAsync(pageName);
        }
        public static void GoToPage(string pageName)
        {
            Shell.Current.GoToAsync(pageName);
        }
        public async static Task LogOutAsync()
        {
            bool result = await Shell.Current.DisplayAlert("Mensaje", "Está seguro que desea cerrar sesión?", "SI", "NO");

            if (result)
            {
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else return;
        }
        public static void LogOut() 
        {
            var result = Shell.Current.DisplayAlert("Mensaje", "Está seguro que desea cerrar sesión?", "SI", "NO");

            if (result.Result)
            {
                Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else return;
        }
    }
}
