using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.Views;
using System.Collections.ObjectModel;

namespace ExploreCity.ViewModels
{
    public partial class ListViewModel : ObservableObject   
    {
        IPinService pinService;

        [ObservableProperty]
        ObservableCollection<PinModel> _pins;

        [ObservableProperty]
        PinModel _selectedPin;

        public ListViewModel(IPinService _pinService)
        {
            _pins = new ObservableCollection<PinModel>();
            this.pinService = _pinService;
        }

        [RelayCommand]
        public async Task GetPins()
        {
            Pins.Clear();

            var result = await pinService.GetPinsAsync();

            foreach (var pin in result)
            {
                Pins.Add(pin);
            }
        }

        [RelayCommand]
        public async void OnFrameClicked(PinModel pin)
        {
            var pinParam = new Dictionary<string, object>();
            pinParam.Add("PinData", pin);
            await Shell.Current.GoToAsync(nameof(DetailsPage), pinParam);
        }

        [RelayCommand]
        public async void LogOut()
        {
            await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
        }


    }
}
