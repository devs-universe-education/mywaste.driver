

using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Work {
	class CompleteOrderViewModel : BaseViewModel {
		public ICommand GoToAddFieldStateCommand => MakeCommand(ShowPageStateAddField);

		private void ShowPageStateAddField() {
			State = PageState.AddField;
		}

		public override async Task OnPageAppearing() {
			State = PageState.Normal;
		}
	}
}
