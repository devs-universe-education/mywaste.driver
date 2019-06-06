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
	}
}
