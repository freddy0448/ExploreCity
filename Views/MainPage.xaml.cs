using ExploreCity.ViewModels;
using ExploreCity.Views;

namespace ExploreCity
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(DetailsPage));
        }
    }
}