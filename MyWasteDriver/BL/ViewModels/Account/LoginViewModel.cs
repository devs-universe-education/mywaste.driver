using System;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;
using Plugin.Connectivity;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Account
{
	class LoginViewModel : BaseViewModel
	{
		public LoginDataObject DataObject
		{
			get => Get<LoginDataObject>();
			private set => Set(value);

		}

		private PermissionStatus status = PermissionStatus.Unknown;




		public ICommand GoToOrdersCommand => MakeCommand(GoToOrdersAsync);

		public  string UserLogin { get; set; }
		public  string UserPassword { get; set; }

		async void GoToOrdersAsync()
		{
			if (UserLogin != null && UserPassword !=null)
			{
				var result = await DataServices.Login.PerformValidation(login: UserLogin, password: UserPassword,  ctx: CancellationToken );

				var access = result.Data.AccessOrNo;

				if (access = true)
				{

					NavigateTo(AppPages.Orders, NavigationMode.Normal);
				}
				else
					ShowAlert("Ошибка", "Неверный логин или пароль!", "Ok");
			}
			else
				ShowAlert("Ошибка", "Введите корректный логин или пароль!", "Ok");
			
		}

		public ICommand CallPhoneCommand => MakeCommand(MakePhoneCommand);

		void MakePhoneCommand() {
			Device.OpenUri(new Uri("tel:88005553535"));
			
		}

		public override async Task OnPageAppearing()
		{
			
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
