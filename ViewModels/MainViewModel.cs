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
            await Shell.Current.GoToAsync(nameof(LogInPage));
        }

        [RelayCommand]
        public async void GoToSignUp()
        {
            await Shell.Current.GoToAsync(nameof(SignUpPage));
        }

        [RelayCommand]
        public async void GoToUsage()
        {
            await Shell.Current.GoToAsync(nameof(UsagePage));
        }
    }
}
