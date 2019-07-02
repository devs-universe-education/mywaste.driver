using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Common {
	class MenuViewModel : BaseViewModel
	{
		public ICommand ExitCommand => MakeCommand(Exit);

		public override async Task OnPageAppearing()
		{
			
		}

		private void Exit()
		{
			NavigateTo(AppPages.Login);
		}
	}
}
