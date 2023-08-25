using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class ListPage : ContentPage
{
	ListViewModel viewModel;
    IPinService pinService;
	public ListPage(ListViewModel listViewModel, IPinService pinService)
	{
		InitializeComponent();
		BindingContext = listViewModel;
		viewModel = listViewModel;
        viewModel.SelectedPin = new PinModel();
        this.pinService = pinService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        pinsListView.ItemsSource = viewModel.Pins;
        viewModel.GetPinsCommand.Execute(null);
    }
    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        SearchBar searchBar = (SearchBar)sender;
        if (string.IsNullOrEmpty(searchBar.Text)) 
        {
            pinsListView.ItemsSource = viewModel.Pins;
        }
        else
        {
            pinsListView.ItemsSource = viewModel.Search(searchBar.Text);
        }
    }
}