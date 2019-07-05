using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using TK.CustomMap;

namespace MyWasteDriver.BL.ViewModels.Complain {
	class SelectComplainTypeViewModel : BaseViewModel {

		public enum ErrorType {
			CantDrive,
			NoAccess,
			NoRecyclables,
			DataError,
			DataErrorEtc
		}


		public MapSpan Position { get; private set; }
		public ICommand GoToReportComplainCommand => GetNavigateToCommand(AppPages.ReportComplain);
		public ICommand GoToReportComplainCantDriveCommand => MakeCommand(GoToReportComplainCantDrive);
		public ICommand GoToReportComplainNoAccessCommand => MakeCommand(GoToReportComplainNoAccess);
		public ICommand GoToReportComplainNoRecyclablesCommand => MakeCommand(GoToReportComplainNoRecyclables);
		public ICommand GoToReportComplainDataErrorCommand => MakeCommand(GoToReportComplainDataError);
		public ICommand GoToReportComplainDataErrorEtcCommand => MakeCommand(GoToReportComplainDataErrorEtc);


		//private Dictionary<string, object> Data;

		private Dictionary<string, object> err (string errorT)
		{
			

			var Data = new Dictionary<string, object>
			{
				{"errorType",errorT}
			};
			return Data;
		}

		private void GoToReportComplainCantDrive()
		{
			NavigateTo(AppPages.ReportComplain, NavigationMode.Normal, toTitle: null, err(ErrorType.CantDrive.ToString()));
		}
		private void GoToReportComplainNoAccess() {
			NavigateTo(AppPages.ReportComplain, NavigationMode.Normal, toTitle: null, err(ErrorType.NoAccess.ToString()));
		}
		private void GoToReportComplainNoRecyclables() {
			NavigateTo(AppPages.ReportComplain, NavigationMode.Normal, toTitle: null, err(ErrorType.NoRecyclables.ToString()));
		}
		private void GoToReportComplainDataError() {
			NavigateTo(AppPages.ReportComplain, NavigationMode.Normal, toTitle: null, err(ErrorType.DataError.ToString()));
		}
		private void GoToReportComplainDataErrorEtc() {
			NavigateTo(AppPages.ReportComplain, NavigationMode.Normal, toTitle: null, err(ErrorType.DataErrorEtc.ToString()));
		}
		public override async Task OnPageAppearing() {
			State = PageState.Normal;
			Position = new MapSpan(new Position(51.712468, 39.181733), 0.2, 0.2);
		}
	}
}
