

using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Work
{
    class OrderInfoViewModel : BaseViewModel
    {
		public ICommand GoToCurrentOrderCommand => GetNavigateToCommand(AppPages.CurrentOrder, NavigationMode.Normal);
    }
}
