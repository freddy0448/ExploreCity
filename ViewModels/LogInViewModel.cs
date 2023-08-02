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

        List<string> cUserName;
        List<string> cPassword;

        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        string password;
        public LogInViewModel(/*Auth0Client auth0Client, */IUserService userService) 
        {
            _userService = userService;
            user = new UserModel();
        }

        [RelayCommand]
        public async void LogIn()
        {
            var userList = await _userService.GetUser();
            if (userList.Count > 0)
            {

                cUserName = userList.Select(x => x.UserName).ToList();
                cPassword = userList.Select(x =>x.Password).ToList();
                bool isUserRegistered = (cUserName.Contains(User.UserName) && cPassword.Contains(User.Password)) ? true : false;
                if (isUserRegistered)
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