using ExploreCity.ViewModels;
using Microsoft.Maui.Controls.Maps;

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
        string addressToInsert = pin.ElementAt(2).Thoroughfare + ", " + pin.ElementAt(2).Locality + ", " + pin.ElementAt(2).AdminArea + ", " + pin.ElementAt(2).CountryName;

        _viewModel.Locations.Add(new Models.PinModel()
        {
            Address = addressToInsert,
            Coordinates = UsagePage.tappedLocation,
            LabelDescription = "Nueva ubicacion"
        });

        await _viewModel.SavePin();
    }

}