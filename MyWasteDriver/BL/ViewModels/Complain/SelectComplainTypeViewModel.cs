using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TK.CustomMap;

namespace MyWasteDriver.BL.ViewModels.Complain {
	class SelectComplainTypeViewModel : BaseViewModel {

		public MapSpan Position { get; private set; }
		public ICommand GoToReportComplainCommand => GetNavigateToCommand(AppPages.ReportComplain);
		public override async Task OnPageAppearing() {
			State = PageState.Normal;
			Position = new MapSpan(new Position(51.712468, 39.181733), 0.2, 0.2);
		}
	}
}
