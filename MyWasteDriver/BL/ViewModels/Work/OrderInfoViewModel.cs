using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;
using TK.CustomMap;



namespace MyWasteDriver.BL.ViewModels.Work {
	class OrderInfoViewModel : BaseViewModel {

		public OrderDetailDataObject OrderInfoObject {

			get => Get<OrderDetailDataObject>();
			set => Set(value);


		}

		public ObservableCollection<TKCustomMapPin> _locations;
		public MapSpan _orderPosition;
		public Dictionary<string, object> _dataToLoad;

		public ObservableCollection<TKCustomMapPin> Locations { get { return _locations; } set { _locations = value; } }
		public MapSpan OrderPosition { get { return _orderPosition; } set { _orderPosition = value; } }


		public override async Task OnPageAppearing() {
			State = PageState.Loading;
			if (NavigationParams.TryGetValue("orderId", out var x)) {

				if (int.TryParse(x.ToString(), out var orderID)) {

					var result = await DataServices.Work.GetOrderDetailInfoById(orderID, CancellationToken);
					if (result.IsValid) {
						OrderInfoObject = result.Data;

						_dataToLoad = new Dictionary<string, object> {
							 {"orderId", OrderInfoObject.OrderId }
						};

						State = PageState.Normal;

					}
					else State = PageState.Error;
				}
				else State = PageState.Error;
			}
			else State = PageState.Error;
		}

		public ICommand GoToCurrentOrderCommand => GetNavigateToCommand(AppPages.CurrentOrder, NavigationMode.Normal, navParams: _dataToLoad);


		public ICommand GoToBackCommand => GoBackCommand;
		public ICommand PageStateMapCommand => MakeCommand(ShowPageStateMap);
		public ICommand PageStateNormalCommand => MakeCommand(ShowPageStateNormal);

		void ShowPageStateMap() {


			_orderPosition = new MapSpan(center: OrderInfoObject.Coordinates,longitudeDegrees: OrderInfoObject.Coordinates.Longitude,latitudeDegrees: OrderInfoObject.Coordinates.Latitude);
			_locations = new ObservableCollection<TKCustomMapPin> {

				new TKCustomMapPin{Position = OrderInfoObject.Coordinates, Title = OrderInfoObject.OrderAdress}
			};

			State = PageState.Map;
		}
		void ShowPageStateNormal() {
			State = PageState.Normal;
		}
	}
}

