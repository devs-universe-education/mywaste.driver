using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;
using TK.CustomMap;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Work {
	class CurrentOrderViewModel : BaseViewModel {
		public CurrentOrderDataObject OrderInfoObject {

			get => Get<CurrentOrderDataObject>();
			set => Set(value);
		}


		public ObservableCollection<TKCustomMapPin> _locations;
		public MapSpan _orderPosition;
		
		
		public ObservableCollection<TKCustomMapPin> Locations { get { return _locations; } set { _locations = value; } }
		public MapSpan OrderPosition { get { return _orderPosition; } set { _orderPosition = value; } }

		public ICommand OpenNavigatorCommand => MakeCommand(OpenNavigator);
		public ICommand GoToCompleteOrderCommand => GetNavigateToCommand(AppPages.CompleteOrder, NavigationMode.Normal);

		public ICommand CallPhoneCommand => MakeCommand(MakePhoneCommand);

		void MakePhoneCommand() {
			Device.OpenUri(new Uri("tel:999999999999999"));

		}

		void OpenNavigator() {

			Device.OpenUri(new Uri("http://maps.google.com/maps?q=" + OrderInfoObject.Coordinates.Latitude + ',' + OrderInfoObject.Coordinates.Longitude + "(" + OrderInfoObject.Material + ")&z=15"));
		}
		public override async Task OnPageAppearing() {

			State = PageState.Loading;

			if (NavigationParams.TryGetValue("orderId", out var x)) {

				if (int.TryParse(x.ToString(), out var orderID)) {

					var result = await DataServices.Work.GetCurrentOrderInfoById(orderID, CancellationToken);
					if (result.IsValid) {
						OrderInfoObject = result.Data;

						_orderPosition = new MapSpan(center: OrderInfoObject.Coordinates, longitudeDegrees: OrderInfoObject.Coordinates.Longitude, latitudeDegrees: OrderInfoObject.Coordinates.Latitude);
						_locations = new ObservableCollection<TKCustomMapPin> {

						new TKCustomMapPin{Position = OrderInfoObject.Coordinates, Title = OrderInfoObject.OrderAdress}
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
