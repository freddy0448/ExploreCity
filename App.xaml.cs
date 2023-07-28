using ExploreCity.Views;

namespace ExploreCity
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            Routing.RegisterRoute(nameof(LogInPage), typeof(LogInPage));
            Routing.RegisterRoute(nameof(SignUpPage), typeof(SignUpPage));
        }
    }
}