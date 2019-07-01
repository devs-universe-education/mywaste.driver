using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Work {
	class PointInfoViewModel: BaseViewModel
	{
		public ICommand GoToSelectComplainTypeCommand => GetNavigateToCommand(AppPages.SelectComplainType);
		public override async Task OnPageAppearing() {
			State = PageState.Normal;
		}
	}
}
