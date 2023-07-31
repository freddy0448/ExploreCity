using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class UsagePage : ContentPage
{
	public UsagePage(UsageViewModel usageViewModel)
	{
		InitializeComponent();
		BindingContext = usageViewModel;
	}
}