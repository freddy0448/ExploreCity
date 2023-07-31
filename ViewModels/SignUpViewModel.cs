using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using ExploreCity.Services;
using ExploreCity.Views;

namespace ExploreCity.ViewModels
{
    public partial class SignUpViewModel : ObservableObject
    {
        IUserService _userService;

        [ObservableProperty]
        UserModel user;

        [ObservableProperty]
        string passwordConfirmation;

        public SignUpViewModel(IUserService userService)
        {
            _userService = userService;
        }

        [RelayCommand]
        public async void RegisterUser()
        {
            var userList = await _userService.GetUser();
            if (userList.Count > 0)
            {
                bool isUserRegistered = userList.Equals(User);

                if (User.Password == PasswordConfirmation)
                    AddUser(isUserRegistered);
                else
                    await Shell.Current.DisplayAlert("Mensaje", "La contraseña y la confirmación son diferentes, favor de ingresar la misma contraseña", "OK");  
            }
            else
            {
                AddUser(false);
            }
        }

        private async void AddUser(bool isRegistered)
        {
            if (isRegistered == false)
            {
                await _userService.AddUser(User);
                await Shell.Current.DisplayAlert("Mensaje", "Usuario registrado exitosamente", "OK");
                await Shell.Current.GoToAsync(nameof(UsagePage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Mensaje", "El usuario ya existe", "OK");
            }
        }

    }

}