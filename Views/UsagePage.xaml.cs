using ExploreCity.Core;
using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.ViewModels;
using Microsoft.Maui.Controls.Maps;

namespace ExploreCity.Views;

public partial class UsagePage : ContentPage    //razones de cambio: 1-cambio en el modelo. 2-cambio en el api del mapa
{
    public static Microsoft.Maui.Devices.Sensors.Location tappedLocation;
    private UsageViewModel _viewModel;
    private IPinService pinService;

    public UsagePage(UsageViewModel usageViewModel, IPinService _pinService)
    {
        InitializeComponent();
        BindingContext = usageViewModel;
        _viewModel = usageViewModel;
        pinService = _pinService;
    }

    public async void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        bool savePin = await Shell.Current.DisplayAlert("Mensaje", "Desea guardar la nueva marca?", "SI", "NO");

        if (savePin)
        {
            tappedLocation = new Microsoft.Maui.Devices.Sensors.Location(e.Location);

            var pin = await Geocoding.GetPlacemarksAsync(UsagePage.tappedLocation);
            string addressToInsert = pin.ElementAt(2).Thoroughfare + ", " + pin.ElementAt(2).Locality + ", " + pin.ElementAt(2).AdminArea + ", " + pin.ElementAt(2).CountryName;

            _viewModel.Locations.Add(new Models.PinModel()
            {
                Address = addressToInsert,
                Latitude = UsagePage.tappedLocation.Latitude,
                Longitude = UsagePage.tappedLocation.Longitude,
                Coordinates = UsagePage.tappedLocation,
                LabelDescription = "Nueva ubicación",
                Id = UsagePage.tappedLocation.Latitude.ToString() + " , " + UsagePage.tappedLocation.Longitude.ToString(),
            });

            await _viewModel.SavePin();

            await Core.Core.GoToDetailsWithDataAsync(_viewModel.Locations.Last());
        }
        else return;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetPinsCommand.Execute(null);
    }
    private void Pin_InfoWindowClicked(object sender, PinClickedEventArgs e)
    {
        var pin = (Pin)sender;
        string pinId = pin.Location.Latitude.ToString() + " , " + pin.Location.Longitude.ToString();
        var desc = pinService.GetSpecifiedPin(pinId);

        PinModel pinModel = new PinModel()
        {
            Address = pin.Address,
            LabelDescription = pin.Label,
            Latitude = pin.Location.Latitude,
            Longitude = pin.Location.Longitude,
            Coordinates = pin.Location,
            PlaceDescription = desc.Result.PlaceDescription,
            ImageFullPath = desc.Result.ImageFullPath,
            Id = pinId
        };

        Core.Core.GoToDetailsWithData(pinModel);
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}