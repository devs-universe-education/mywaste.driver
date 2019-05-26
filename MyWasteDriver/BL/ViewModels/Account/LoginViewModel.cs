using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Account
{
	class LoginViewModel : BaseViewModel 
	{


		public ICommand GoToOrdersCommand => GetNavigateToCommand(AppPages.Orders, NavigationMode.Normal, null, false, true, false);

		public ICommand CallPhoneCommand => MakeCommand(MakePhoneCommand);

		void MakePhoneCommand() {
			Device.OpenUri(new Uri("tel:999999999999999"));
			
		}

		public override async Task OnPageAppearing() {
			
			State = PageState.Normal;

		

		}  

		
	}

}
