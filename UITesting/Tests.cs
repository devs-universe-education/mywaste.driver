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
			app.Tap("ButtonVhod");
			app.Repl();
		}
		[Test]
		public void ExtendedPattern() {

			//app.EnterText("EntryLog", "admin"); 
			app.EnterText("EntryLog", "admin");
			app.EnterText("EntryPassword", "admin");
			app.Tap("ButtonVhod");

			app.WaitForElement("ButtonToInfo");

			app.Tap("ButtonToInfo");

			app.WaitForElement("ButtonTocurrent");
			//app.ScrollDown(); 
			//app.ScrollUp(); 
			app.Tap("ButtonTocurrent");

			//app.Tap("Navigate"); 
			//app. 

			app.WaitForElement("ButtonToComplete");

			app.Tap("ButtonToComplete");

			app.WaitForElement("ButtonComplete");

			app.Tap("ButtonComplete");

			app.Repl();
		}
	}
}
