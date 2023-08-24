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
            int insertResponse = 0;
            var deleteResponse = await _pinService.DeleteAllPinsAsync();
            foreach (var location in Locations)
            {
                var responseInsert = _pinService.InsertPinAsync(location);
                insertResponse = await responseInsert;
            }
            Locations.Last().Coordinates = null;
            return insertResponse;
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

        [RelayCommand]
        public async void GoToList()
        {
            await Shell.Current.GoToAsync(nameof(ListPage));
        }

    }
}
