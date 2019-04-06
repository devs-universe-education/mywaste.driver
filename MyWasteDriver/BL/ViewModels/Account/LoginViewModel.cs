using System.Threading.Tasks;
using System.Windows.Input;


namespace MyWasteDriver.BL.ViewModels.Account
{
	class LoginViewModel : BaseViewModel 
	{


		public ICommand GoToOrdersCommand => GetNavigateToCommand(AppPages.Orders, NavigationMode.Normal, null, false, true, false);
		


		public override async Task OnPageAppearing() {
			
			State = PageState.Normal;
			 	
		}  

		
	}
}
