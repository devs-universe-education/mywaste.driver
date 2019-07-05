using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Akavache;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataObjects.Login;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Common {
	class MenuViewModel : BaseViewModel {
		public ICommand ExitCommand => MakeCommand(Exit);

		public UserInfoObject UserInfo {
			get => Get<UserInfoObject>();
			set => Set(value);
		}
		public string addres => _addres;
		string _addres;

		public override async Task OnPageAppearing() {
			UserInfo = await BlobCache.UserAccount.GetObject<UserInfoObject>("user");
			_addres = UserInfo.CompanyName + UserInfo.CompanyAddress + UserInfo.CompanyPhoneNumber;
		}

		private async void Exit() {
			await BlobCache.UserAccount.Invalidate("user");
			NavigateTo(AppPages.Login, NavigationMode.Root, newNavigationStack: true);
		}
	}
}