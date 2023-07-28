using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class SignUpPage : ContentPage
{
	SignUpViewModel _signUpViewModel;
	public SignUpPage(SignUpViewModel signUpViewModel)
	{
        InitializeComponent();
		_signUpViewModel = signUpViewModel;
		BindingContext = _signUpViewModel;
	}
}