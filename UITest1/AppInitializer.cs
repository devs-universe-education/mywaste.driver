using System;
using Xamarin.UITest;

namespace UITest1
{
	public class AppInitializer
	{
		//-------------------------------------------------
        //U MUST BUILD RELEASE VERSION BEFORE START UI TEST
        //-------------------------------------------------

		const string ApkFile = "../../../MyWasteDriver.Android/bin/Release/com.binwell.university.MyWasteDriver-Signed.apk";
      

		static IApp _app;

		public static IApp App
		{
			get
			{
				if (_app == null)
					throw new NullReferenceException("AppInitializer.App' not set.");
				return _app;
			}
		}

		public static IApp StartApp(Platform platform)
		{
			if (platform == Platform.Android)
			{
				_app = ConfigureApp.Android.ApkFile(ApkFile)
					.StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
			}
		

			return _app;
		}
	}
}
