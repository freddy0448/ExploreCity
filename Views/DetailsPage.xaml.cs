using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsViewModel detailsViewModel)
    {
        InitializeComponent();
        BindingContext = detailsViewModel;
    }
}