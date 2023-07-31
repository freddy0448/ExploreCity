using ExploreCity.Auth0;
using ExploreCity.Services;
using ExploreCity.ViewModels;
using ExploreCity.Views;
using Microsoft.Extensions.Logging;

namespace ExploreCity
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiMaps()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();


#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<LogInViewModel>();
            builder.Services.AddTransient<LogInPage>();

            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<SignUpViewModel>();

            builder.Services.AddSingleton<IUserService, UserService>();

            builder.Services.AddSingleton<UsagePage>();
            builder.Services.AddSingleton<UsageViewModel>();

            builder.Services.AddSingleton(new Auth0Client(new()
            {
                Domain = "freddy0448.us.auth0.com",
                ClientId = "qHZARDum1odUK9z6sLEfsSJ3OgBAzIOL",
                Scope = "openid profile",
                RedirectUri = "myapp://callback"
            }));
            return builder.Build();
        }
    }
}