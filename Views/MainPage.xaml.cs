using ExploreCity.Auth0;
using ExploreCity.ViewModels;

namespace ExploreCity
{
    public partial class MainPage : ContentPage
    {
        private readonly Auth0Client _auth0Client;
        public MainPage(MainViewModel mainViewModel, Auth0Client auth0Client)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
            _auth0Client = auth0Client;
        }
    }
}