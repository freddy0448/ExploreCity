using ExploreCity.ViewModels;
using Microsoft.Maui.Controls.Maps;

namespace ExploreCity.Views;

public partial class UsagePage : ContentPage
{
    object sender;
    MapClickedEventArgs e;
    public static Location tappedLocation;
    public UsagePage(UsageViewModel usageViewModel)
    {
        InitializeComponent();
        BindingContext = usageViewModel;
    }

    public void OnMapClicked(object sender, MapClickedEventArgs e)
    {
        double latitude = e.Location.Latitude;
        double longitude = e.Location.Longitude;
        tappedLocation = new Location(latitude, longitude);
        this.sender = sender;
        this.e = e;
    }

    public object GetSender()
    {
        return sender;
    }

    public MapClickedEventArgs GetMapClickedEventArgs()
    {
        return e;
    }
}