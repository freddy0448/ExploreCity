using ExploreCity.ViewModels;
using Microsoft.Maui.Controls;

namespace ExploreCity.Views;

public partial class DetailsPage : ContentPage
{
    DetailsViewModel viewModel;
    public DetailsPage(DetailsViewModel detailsViewModel)
    {
        InitializeComponent();
        BindingContext = detailsViewModel;
        viewModel = detailsViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}