using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace UITest1
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

		public IApp App { get => app; set => app = value; }

		[SetUp]
        public void BeforeEachTest()
        {
            App = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
			App.EnterText("EntryLog", "111");
			App.Repl();
        }
    }
}
