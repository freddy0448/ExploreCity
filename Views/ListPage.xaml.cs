using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class ListPage : ContentPage
{
	public ListPage(ListViewModel listViewModel)
	{
		InitializeComponent();
		BindingContext = listViewModel;
	}
}