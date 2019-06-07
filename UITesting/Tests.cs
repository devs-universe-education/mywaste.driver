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
		public void OrdersTest() {

			app.ScrollDown();
			app.ScrollUp();
			app.Tap("ButtonTocurrent");

		}

		[Test]
		public void OrderInfoTest() {

			app.Tap("ButtonTocurrent");

		}

		[Test]
		public void CurrentOrderTest() {

			app.Tap("ButtonToComplete");

		}

		[Test]
		public void CompleteOrderTest() {

			app.Tap("ButtonComplete");

		}

		[Test]
		public void MainPattern() {

			app.Tap("ButtonToInfo");

			app.ScrollDown();
			app.ScrollUp();
			app.Tap("ButtonTocurrent");

			app.Tap("ButtonToComplete");

			app.Repl();
		}

		[Test]
		public void ExtendedPattern() {

			app.EnterText("EntryLog", "admin");
			app.EnterText("EntryLog", "admin");
			app.EnterText("EntryPassword", "admin");
			app.Tap("ButtonVhod");

			app.WaitForElement("ButtonToInfo");
			app.Tap("ButtonToInfo");

			app.ScrollDown();
			app.ScrollUp();
			app.WaitForElement("ButtonTocurrent");
			app.Tap("ButtonTocurrent");

			//app.Tap("Navigate");
			
			app.WaitForElement("ButtonToComplete");
			app.Tap("ButtonToComplete");

			app.WaitForElement("ButtonComplete");
			app.Tap("ButtonComplete");

			app.Repl();
		}
	}
}
