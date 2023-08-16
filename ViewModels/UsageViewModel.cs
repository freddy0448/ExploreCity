using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.Views;
using System.Collections.ObjectModel;

namespace ExploreCity.ViewModels
{
    public partial class UsageViewModel : ObservableObject
    {
        [ObservableProperty]
        Location _coordinates;

        [ObservableProperty]
        string _address;

        [ObservableProperty]
        string _labelDescription;

        [ObservableProperty]
        PinModel _pinModel;

        [ObservableProperty]
        ObservableCollection<PinModel> _locations;

        private IPinService _pinService;
        public UsageViewModel(IPinService pinService)
        {
            _pinService = pinService;
            _pinModel = new PinModel();
            _locations = new ObservableCollection<PinModel>();
        }

        [RelayCommand]
        public async Task<int> SavePin()
        {
            int response = 0;

            bool savePin = await Shell.Current.DisplayAlert("Mensaje", "Desea guardar la nueva marca?", "SI", "NO");

            if (savePin)
            {
                //await _pinService.DeleteAllPinsAsync();

                foreach (var location in Locations)
                {
                    var responseInsert = _pinService.InsertPinAsync(location);
                    response = await responseInsert;
                }
            }
            else if (!savePin)
                Locations.Last().Coordinates = null;
            return response;
        }

        [RelayCommand]
        public async Task<List<PinModel>> GetPinsAsync()
        {
            Locations.Clear();
            var result = await _pinService.GetPinsAsync();

            if (result != null)
                foreach (var pin in result)
                {
                    pin.Coordinates = new Location()
                    {
                        Latitude = pin.Latitude,
                        Longitude = pin.Longitude
                    };

                    Locations.Add(pin);

                    Coordinates = new Location()
                    {
                        Latitude = pin.Latitude,
                        Longitude = pin.Longitude
                    };
                }

            return result;
        }

        [RelayCommand]
        public async void LogOut()
        {
            await Shell.Current.GoToAsync("../..");
        }
    }
}
