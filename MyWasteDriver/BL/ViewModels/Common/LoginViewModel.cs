using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Common {
	class LoginViewModel : BaseViewModel
	{

		public ICommand GoToPointsPageCommand => MakeCommand(GoToPoints);

		private void GoToPoints()
		{
			NavigateTo(AppPages.PointInfo);
		}

		public override async Task OnPageAppearing()
		{
			State = PageState.EnterPhone;
		}
	}
}
