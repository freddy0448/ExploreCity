using Android.App;
using Android.Content.PM;
using Android.Content;

namespace ExploreCity.Platforms.Android
{

    //[Activity(NoHistory = true, LaunchMode = LaunchMode.SingleTop, Exported = true)]
    //[intentfilter(new[] { android.content.intent.actionview },
    //          categories = new[] {
    //            android.content.intent.categorydefault,
    //            android.content.intent.categorybrowsable
    //          },
    //          datascheme = callback_scheme)]
    public class WebAuthenticationCallbackActivity : Microsoft.Maui.Authentication.WebAuthenticatorCallbackActivity
    {
        const string CALLBACK_SCHEME = "myapp";
    }
}
