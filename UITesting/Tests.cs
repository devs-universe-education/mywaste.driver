using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UITesting
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
		public void WelcomeTextIsDisplayed() {

			app.EnterText("EntryLog", "admin");
			app.EnterText("EntryPassword", "admin");
	        app.TapCoordinates(540,1572);
			
		}
		[Test]
		public void OrdersTest()
		{
			WelcomeTextIsDisplayed();
			app.Tap("ButtonTocurrent");

		}

		[Test]
		public void OrderInfoTest() {

			app.WaitForElement("ButtonToInfo");

			app.TapCoordinates(540, 350);

		}

		[Test]
		public void CurrentOrderTest()
		{
			OrderInfoTest();
			app.WaitForElement("ButtonTocurrent");

			app.Tap("ButtonTocurrent");

		}

		[Test]
		public void CompleteOrderTest()
		{

			CurrentOrderTest();

			app.Tap("ButtonComplete");

		}

		//[Test]
		//public void MainPattern() {

		//	app.Tap("ButtonToInfo");

		//	app.ScrollDown();
		//	app.ScrollUp();
		//	app.Tap("ButtonTocurrent");

		//	app.Tap("ButtonToComplete");

		//	app.Repl();
		//}

		[Test]
		public void ExtendedPattern() {

			WelcomeTextIsDisplayed();
			

			app.WaitForElement("ButtonToInfo");

			app.TapCoordinates(540, 350);

			app.WaitForElement("ButtonTocurrent");
			 
			app.Tap("ButtonTocurrent");

			//app.Tap("Navigate"); 
			//app. 

			app.WaitForElement("ButtonToComplete");

			app.TapCoordinates(540, 1688);

			app.WaitForElement("ButtonComplete");

			app.TapCoordinates(270, 1688);

			
		}
	}
}
