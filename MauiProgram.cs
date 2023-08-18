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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiMaps();

#if DEBUG
            builder.Logging.AddDebug();


#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<LogInViewModel>();
            builder.Services.AddTransient<LogInPage>();

            builder.Services.AddTransient<SignUpPage>();
            builder.Services.AddTransient<SignUpViewModel>();

            builder.Services.AddSingleton<UsagePage>();
            builder.Services.AddSingleton<UsageViewModel>();

            builder.Services.AddTransient<DetailsViewModel>();
            builder.Services.AddTransient<DetailsPage>();

            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<IPinService, PinService>();

            return builder.Build();
        }
    }
}