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
        UserModel _user;

        [ObservableProperty]
        string _passwordConfirmation;

        public SignUpViewModel(IUserService userService)
        {
            _user = new UserModel();
            _userService = userService;
        }

        [RelayCommand]
        public async void RegisterUser()
        {
            var userList = await _userService.GetUser();
            if (userList.Count > 0)
            {
                bool isUserRegistered = userList.Contains(User);

                if (User.Password == PasswordConfirmation)
                {
                    AddUser(isUserRegistered);
                    EntryClean();
                }
                else
                    await Shell.Current.DisplayAlert("Mensaje", "La contraseña y la confirmación son diferentes, favor de ingresar la misma contraseña", "OK");
            }
            else
            {
                if (User.Password == PasswordConfirmation)
                {
                    AddUser(false);
                    EntryClean();
                }
                else
                {
                    await Shell.Current.DisplayAlert("Mensaje", "La contraseña y la confirmación son diferentes, favor de ingresar la misma contraseña", "OK");
                    EntryClean();
                }

            }
        }

        private async void AddUser(bool isRegistered)
        {
            if (isRegistered == false)
            {
                await _userService.InsertUser(User);
                await Shell.Current.DisplayAlert("Mensaje", "Usuario registrado exitosamente", "OK");
                await Shell.Current.GoToAsync(nameof(UsagePage));
            }
            else
            {
                await Shell.Current.DisplayAlert("Mensaje", "El usuario ya existe", "OK");
                EntryClean();
            }
        }

        private void EntryClean()
        {
            User.UserName = string.Empty;
            User.Password = string.Empty;
            PasswordConfirmation = string.Empty;
        }

    }

}