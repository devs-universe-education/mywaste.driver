

using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Work
{
    class OrdersViewModel : BaseViewModel
    {
		public ICommand GoToOrderInfoCommand => GetNavigateToCommand(AppPages.OrderInfo, NavigationMode.Normal);
		
    }
}
