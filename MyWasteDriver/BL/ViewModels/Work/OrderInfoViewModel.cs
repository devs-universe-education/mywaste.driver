using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;

namespace MyWasteDriver.BL.ViewModels.Work {
	class OrderInfoViewModel : BaseViewModel {

		public OrderDetailDataObject OrderInfoObject {

			get => Get<OrderDetailDataObject>();
			set => Set(value);
		}

		public override async Task OnPageAppearing() {

			State = PageState.Loading;
			if (NavigationParams.TryGetValue("orderId", out var x)) {

				if (int.TryParse(x.ToString(), out var orderID)) {

					var result = await DataServices.Work.GetOrderDetailInfoById(orderID, CancellationToken);
					if (result.IsValid) {
						OrderInfoObject = result.Data;
						State = PageState.Normal;
					}
					else State = PageState.Error;
				}
				else State = PageState.Error;
			}
			else State = PageState.Error;
		}


		public ICommand GoToCurrentOrderCommand => GetNavigateToCommand(AppPages.CurrentOrder, NavigationMode.Normal);
		public ICommand GoToBackCommand => GoBackCommand;
		public ICommand PageStateMapCommand => MakeCommand(ShowPageStateMap);
		public ICommand PageStateNormalCommand => MakeCommand(ShowPageStateNormal);

		void ShowPageStateMap() {
			State = PageState.Map;
		}
		void ShowPageStateNormal() {
			State = PageState.Normal;
		}
	}
}
