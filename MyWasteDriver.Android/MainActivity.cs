using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;
using TK.CustomMap.Droid;
using Plugin.Permissions;
using Android.Runtime;
using TK.CustomMap.Api.Google;

namespace MyWasteDriver.Android
{

    [Activity(Label = "MyWasteDriver", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults) {
			PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
		protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

			UserDialogs.Init(() => this);
			GmsDirection.Init("AIzaSyDJ5OvKyLiF59CsnfI229J8l9mAGr13w8w");
			global::Xamarin.Forms.Forms.Init(this, bundle);
			TKGoogleMaps.Init(this, bundle);
			Plugin.CurrentActivity.CrossCurrentActivity.Current.Init(this, bundle);
			LoadApplication(new App());
        }
		


	}
}


