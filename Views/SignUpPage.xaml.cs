using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class SignUpPage : ContentPage
{
    public SignUpPage(SignUpViewModel signUpViewModel)
    {
        InitializeComponent();
        BindingContext = signUpViewModel;
    }
}