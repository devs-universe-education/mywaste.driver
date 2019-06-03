using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Connectivity;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Account
{
	class LoginViewModel : BaseViewModel 
	{

		PermissionStatus status = PermissionStatus.Unknown;

		public ICommand GoToOrdersCommand => GetNavigateToCommand(AppPages.Orders, NavigationMode.Normal, null, false, true, false);

		public ICommand CallPhoneCommand => MakeCommand(MakePhoneCommand);

		void MakePhoneCommand() {
			Device.OpenUri(new Uri("tel:999999999999999"));
			
		}

		public override async Task OnPageAppearing() {

			if (CrossConnectivity.Current.IsConnected) {

				status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

				if (status == PermissionStatus.Granted) {

					State = PageState.Normal;
				}
				if (status == PermissionStatus.Disabled || status == PermissionStatus.Denied) {

					status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location))[Permission.Location];
					if (status == PermissionStatus.Denied) {
						status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location))[Permission.Location];
					}
				}
			}
			else {
				State = PageState.NoInternet;
			}

		}  

		
	}

}
