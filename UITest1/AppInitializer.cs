using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITest1
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                //return ConfigureApp.Android.StartApp();
				return ConfigureApp
				   .Android
				   .EnableLocalScreenshots()
				   .ApkFile(@"C:\Users\Dmitry\Desktop\mywaste.driver\mywaste.driver\MyWasteDriver.Android\bin\Debug\com.binwell.university.MyWasteDriver-Signed.apk")
				   .StartApp();
			}

            return ConfigureApp.iOS.StartApp();
        }
    }
}