using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Common {
	class MenuViewModel : BaseViewModel
	{
		public ICommand ExitCommand => MakeCommand(Exit);

		private void Exit()
		{
			NavigateTo(AppPages.Login);
		}
	}
}
