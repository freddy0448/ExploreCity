using Android.Locations;
using ExploreCity.ViewModels;
using Microsoft.Maui.Controls.Maps;
using static Android.Media.MicrophoneInfo;

namespace ExploreCity.Views;

public partial class UsagePage : ContentPage
{
    public static Microsoft.Maui.Devices.Sensors.Location tappedLocation;
    private UsageViewModel _viewModel;
    public UsagePage(UsageViewModel usageViewModel)
    {
        InitializeComponent();
        BindingContext = usageViewModel;
        _viewModel = usageViewModel;
    }

    public async void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        tappedLocation = new Microsoft.Maui.Devices.Sensors.Location(e.Location);

        var pin = await Geocoding.GetPlacemarksAsync(UsagePage.tappedLocation);
        _viewModel.Locations.Add(new Models.PinModel()
        {
            Address = pin.ElementAt(3).FeatureName,
            Coordinates = UsagePage.tappedLocation,
            LabelDescription = "Nueva ubicacion"
        });
    }
}