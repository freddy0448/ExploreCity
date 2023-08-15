using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.ViewModels;
using Microsoft.Maui.Controls.Maps;

namespace ExploreCity.Views;

public partial class UsagePage : ContentPage
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
        tappedLocation = new Microsoft.Maui.Devices.Sensors.Location(e.Location);

        var pin = await Geocoding.GetPlacemarksAsync(UsagePage.tappedLocation);
        string addressToInsert = pin.ElementAt(2).Thoroughfare + ", " + pin.ElementAt(2).Locality + ", " + pin.ElementAt(2).AdminArea + ", " + pin.ElementAt(2).CountryName;

        _viewModel.Locations.Add(new Models.PinModel()
        {
            Address = addressToInsert,
            Latitude = UsagePage.tappedLocation.Latitude,
            Longitude = UsagePage.tappedLocation.Longitude,
            Coordinates = UsagePage.tappedLocation,
            LabelDescription = "Nueva ubicacion"
        });

        await _viewModel.SavePin();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.GetPinsCommand.Execute(null);
    }
    private void Pin_InfoWindowClicked(object sender, PinClickedEventArgs e)
    {
        var pin = (Pin)sender;
        var desc = pinService.GetSpecifiedPin(pin.Location.Longitude);

        PinModel pinModel = new PinModel()
        {
            Address = pin.Address,
            LabelDescription = pin.Label,
            Latitude = pin.Location.Latitude,
            Longitude = pin.Location.Longitude,
            Coordinates = pin.Location,
            PlaceDescription = desc.Result.PlaceDescription,
            ImageFullPath = desc.Result.ImageFullPath
        };

        var varParam = new Dictionary<string, object>();
        varParam.Add("PinData", pinModel);
        Shell.Current.GoToAsync(nameof(DetailsPage), varParam);
    }
}