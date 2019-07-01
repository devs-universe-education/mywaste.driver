using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.UI.Pages;

namespace MyWasteDriver.BL.ViewModels.Work {
	class PointsViewModel : BaseViewModel
	{

		public ICommand GoToPointInfoCommand => GetNavigateToCommand(AppPages.PointInfo);

		public override async Task OnPageAppearing() {
			State = PageState.Normal;
		}
	}
}
