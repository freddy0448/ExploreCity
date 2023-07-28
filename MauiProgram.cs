﻿using ExploreCity.Auth0;
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