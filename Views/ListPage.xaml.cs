using ExploreCity.Models;
using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class ListPage : ContentPage
{
	ListViewModel viewModel;
	public ListPage(ListViewModel listViewModel)
	{
		InitializeComponent();
		BindingContext = listViewModel;
		viewModel = listViewModel;
        viewModel.SelectedPin = new PinModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.GetPinsCommand.Execute(null);
    }
}