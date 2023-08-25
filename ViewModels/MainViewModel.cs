using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Views;

namespace ExploreCity.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {

        [RelayCommand]
        public async void GoToLogIn()
        {
            await Core.Core.GoToPageAsync(nameof(LogInPage));
        }

        [RelayCommand]
        public async void GoToSignUp()
        {
            await Core.Core.GoToPageAsync(nameof(SignUpPage));
        }
    }
}
