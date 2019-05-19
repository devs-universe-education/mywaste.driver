

using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Work
{
    class CurrentOrderViewModel : BaseViewModel
    {
		public ICommand GoToCompleteOrderCommand => GetNavigateToCommand(AppPages.CompleteOrder, NavigationMode.Normal);
	}
}
