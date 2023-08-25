using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.Views;

namespace ExploreCity.ViewModels
{
    public partial class LogInViewModel : ObservableObject      //manejar funcionalidades basicas del login
                                                                //razones de cambio: 1-cambio en la autenticacion del sistema
    {
        private IUserService _userService;

        List<string> cUserName;
        List<string> cPassword;

        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        string password;
        public LogInViewModel(IUserService userService)
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
                cPassword = userList.Select(x => x.Password).ToList();
                bool isUserRegistered = (cUserName.Contains(User.UserName) && cPassword.Contains(User.Password)) ? true : false;
                if (isUserRegistered)
                {
                    CleanEntries();

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
        void GoToUsagePage()
        {
            Core.Core.GoToPage(nameof(UsagePage));
        }

        private void CleanEntries()
        {
            User.UserName = string.Empty;
            User.Password = string.Empty;
            Password = string.Empty;
        }

    }
}