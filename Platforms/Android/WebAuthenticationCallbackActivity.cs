using Android.App;
using Android.Content.PM;


namespace ExploreCity.Platforms.Android
{

    [Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
    public class WebAuthenticationCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
    {
        const string CALLBACK_SCHEME = "myapp";

    }
}