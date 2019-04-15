

using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;

namespace MyWasteDriver.BL.ViewModels.Work
{
   public class OrdersViewModel : BaseViewModel
    {
		public OrdersDataObject OrdersObject {
			get => Get<OrdersDataObject>();
			private set => Set(value);
		}

		public ICommand GoToOrderInfoCommand => GetNavigateToCommand(AppPages.OrderInfo, NavigationMode.Normal);

		public override async Task OnPageAppearing() {
			State = PageState.Loading;
			var result = await DataServices.Work.GetOrdersInfo(CancellationToken);
			if (result.IsValid) {
			OrdersObject = result.Data;
			State = PageState.Normal;
		}
		else
		State = PageState.Error;
	}
}
}
