using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Auth0;

namespace ExploreCity.ViewModels
{
    public partial class LogInViewModel : ObservableObject
    {
        private readonly Auth0Client _client;
        public LogInViewModel(Auth0Client auth0Client) 
        {
            _client = auth0Client;
        }

        [RelayCommand]
        public async void LogIn()
        {
            var loginResult = await _client.LoginAsync();

            if(!loginResult.IsError) 
            { 
                
            }
        }
    }
}