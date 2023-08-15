using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class LogInPage : ContentPage
{
    //private readonly Auth0Client _auth0Client;
    public LogInPage(LogInViewModel logInViewModel/*, Auth0Client auth0Client*/)
    {
        InitializeComponent();
        BindingContext = logInViewModel;
        //_auth0Client = auth0Client;
    }
}