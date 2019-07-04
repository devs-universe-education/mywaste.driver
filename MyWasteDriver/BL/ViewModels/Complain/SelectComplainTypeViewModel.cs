using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Complain {
	class SelectComplainTypeViewModel : BaseViewModel {
		public ICommand GoToReportComplainCommand => GetNavigateToCommand(AppPages.ReportComplain);
		public override async Task OnPageAppearing() {
			State = PageState.Normal;
		}
	}
}
