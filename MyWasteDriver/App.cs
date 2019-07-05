using System;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using MyWasteDriver.DAL.DataObjects.Login;
using MyWasteDriver.DAL.DataServices;
using MyWasteDriver.UI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyWasteDriver {


	public class App : Application {

		bool _checkLoginAsync;
		public App() {
			DialogService.Init(this);
			NavigationService.Init(this);
			DataServices.Init(true);

		}

		protected override async void OnStart() {
			BlobCache.ApplicationName = "MyWasteDriver";
			NavigationService.Instance.SetMainPage(AppPages.Login);

		}





	}
}