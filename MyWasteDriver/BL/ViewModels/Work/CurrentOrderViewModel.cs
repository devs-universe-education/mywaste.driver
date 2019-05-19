using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;
using Xamarin.Forms.Maps;

namespace MyWasteDriver.BL.ViewModels.Work {
	class CurrentOrderViewModel : BaseViewModel {
		public CurrentOrderDataObject OrderInfoObject {

			get => Get<CurrentOrderDataObject>();
			set => Set(value);
		}

		public ObservableCollection<Pin> _locations;
		public Position _userPosition;


		public ObservableCollection<Pin> Locations { get { return _locations; } set { _locations = value; } }
		public Position UserPosition { get { return _userPosition; } set { _userPosition = value; } }

		public ICommand GoToCompleteOrderCommand => GetNavigateToCommand(AppPages.CompleteOrder, NavigationMode.Normal);

		public override async Task OnPageAppearing() {

			State = PageState.Loading;

			if (NavigationParams.TryGetValue("orderId", out var x)) {

				if (int.TryParse(x.ToString(), out var orderID)) {

					var result = await DataServices.Work.GetCurrentOrderInfoById(orderID, CancellationToken);
					if (result.IsValid) {
						OrderInfoObject = result.Data;

						_userPosition = OrderInfoObject.Coordinates;
						_locations = new ObservableCollection<Pin> {

						new Pin{Position = OrderInfoObject.Coordinates, Type = PinType.Generic, Label = OrderInfoObject.Material, Address = OrderInfoObject.OrderAdress}
						};

						State = PageState.Normal;

					}
					else State = PageState.Error;
				}
				else State = PageState.Error;
			}
			else State = PageState.Error;
		}
	}
}
