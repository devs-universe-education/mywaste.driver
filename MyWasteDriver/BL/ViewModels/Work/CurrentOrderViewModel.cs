using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;
using Plugin.Geolocator;
using TK.CustomMap;
using TK.CustomMap.Overlays;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Work {
	class CurrentOrderViewModel : BaseViewModel {
		public CurrentOrderDataObject OrderInfoObject {

			get => Get<CurrentOrderDataObject>();
			set => Set(value);
		}

		public ObservableCollection<TKRoute> _routes;
		public ObservableCollection<TKRoute> Routes { get { return _routes; } set { _routes = value; } }


		public ObservableCollection<TKCustomMapPin> _locations;
		public MapSpan _orderPosition;
		
		public ObservableCollection<TKCustomMapPin> Locations { get { return _locations; } set { _locations = value; } }
		public MapSpan OrderPosition { get { return _orderPosition; } set { _orderPosition = value; } }

		public ICommand OpenNavigatorCommand => MakeCommand(OpenNavigator);
		public ICommand GoToCompleteOrderCommand => GetNavigateToCommand(AppPages.CompleteOrder, NavigationMode.Normal);
		public ICommand CallPhoneCommand => MakeCommand(MakePhoneCommand);
		
		void MakePhoneCommand() {

			Device.OpenUri(new Uri("tel:88005553535"));
		}

		void OpenNavigator() {

			Device.OpenUri(new Uri("http://maps.google.com/maps?q=" + OrderInfoObject.Coordinates.Latitude + ',' + OrderInfoObject.Coordinates.Longitude + "(" + OrderInfoObject.Material + ")&z=15"));
		}
		public override async Task OnPageAppearing() {

			State = PageState.Loading;

			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(1));
			
			if (NavigationParams.TryGetValue("orderId", out var x)) {

				if (int.TryParse(x.ToString(), out var orderID)) {

					var result = await DataServices.Work.GetCurrentOrderInfoById(orderID, CancellationToken);
					if (result.IsValid) {
						OrderInfoObject = result.Data;

						_orderPosition = new MapSpan(center: OrderInfoObject.Coordinates, longitudeDegrees: OrderInfoObject.Coordinates.Longitude, latitudeDegrees: OrderInfoObject.Coordinates.Latitude);
						_locations = new ObservableCollection<TKCustomMapPin> {

						new TKCustomMapPin{Position = OrderInfoObject.Coordinates, Title = OrderInfoObject.OrderAdress}
						};

						_routes = new ObservableCollection<TKRoute> { new TKRoute { Destination = OrderInfoObject.Coordinates,Source =  new Position(position.Latitude, position.Longitude), TravelMode = TKRouteTravelMode.Driving, Color = Xamarin.Forms.Color.Black, Selectable = false, LineWidth = 10 } };
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
