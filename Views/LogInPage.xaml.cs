using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class LogInPage : ContentPage
{
	public LogInPage(LogInViewModel logInViewModel)
	{
		InitializeComponent();
		BindingContext = logInViewModel;
	}
}