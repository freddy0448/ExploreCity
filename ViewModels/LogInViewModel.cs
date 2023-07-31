using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Auth0;
using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.Views;

namespace ExploreCity.ViewModels
{
    public partial class LogInViewModel : ObservableObject
    {
        //private readonly Auth0Client _client;
        private IUserService _userService;

        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        string password;
        public LogInViewModel(/*Auth0Client auth0Client*/ IUserService userService) 
        {
            _userService = userService;

            //_client = auth0Client;
//#if WINDOWS
//    _client.Browser = new WebViewBrowserAuthenticator(WebViewInstance);
//#endif
        }

        [RelayCommand]
        public async void LogIn()
        {
            var userList = await _userService.GetUser();
            if (userList.Count > 0)
            {
                bool isUserRegistered = userList.Equals(User);
                bool isPasswordCorrect = Password.Equals(User.Password);
                if (isUserRegistered && isPasswordCorrect)
                {
                    GoToUsagePage();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Mensaje", "Usuario y/o contraseña incorrecta", "OK");
                    return;
                }

            }
            else
            {
                await Shell.Current.DisplayAlert("Mensaje", "El usuario no existe", "OK");
            }
        }

        [RelayCommand]
        async void GoToUsagePage()
        {
            await Shell.Current.GoToAsync(nameof(UsagePage));
        }
    }
}