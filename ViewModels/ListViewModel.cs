using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Core;
using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.Views;
using System.Collections.ObjectModel;

namespace ExploreCity.ViewModels
{
    public partial class ListViewModel : ObservableObject    //Lidea con las acciones necesarias para mostrar y manejar la lista de marcadores
                                                            //razones de cambio: 1-cambios en los campos tomados en cuenta para la busqueda
    {
        IPinService pinService;

        [ObservableProperty]
        ObservableCollection<PinModel> _pins;

        [ObservableProperty]
        PinModel _selectedPin;

        [ObservableProperty]
        string _searchText;

        [ObservableProperty]
        ObservableCollection<PinModel> _searchResults;

        public ListViewModel(IPinService _pinService)
        {
            _pins = new ObservableCollection<PinModel>();
            _searchResults = new ObservableCollection<PinModel>();
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
            await Core.Core.GoToDetailsWithDataAsync(pin);
            SearchText = string.Empty;
        }

        [RelayCommand]
        public async void LogOut()
        {
            await Core.Core.LogOutAsync();
        }

        public ObservableCollection<PinModel> Search(string searchText)
        {
            SearchResults.Clear();
            foreach (var pin in Pins)
            {
                bool doesThePinExists = pin.LabelDescription.ToLower().Contains(searchText.ToLower());

                if (doesThePinExists)
                {
                    SearchResults.Add(pin);
                }
            }
            return SearchResults;
        }
    }
}
