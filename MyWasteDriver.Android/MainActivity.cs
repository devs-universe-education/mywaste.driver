using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using TK.CustomMap.Api.Google;
using TK.CustomMap.Droid;
using Plugin.CurrentActivity;
using Plugin.Permissions;

namespace MyWasteDriver.Android
{
    [Activity(Label = "MyWasteDriver", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

	    //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults) {
		   // Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
	    //}

		protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            GmsDirection.Init("AIzaSyDJ5OvKyLiF59CsnfI229J8l9mAGr13w8w");
            UserDialogs.Init(() => this);
            TKGoogleMaps.Init(this, bundle);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
			LoadApplication(new App());
		
		}
    }
}


