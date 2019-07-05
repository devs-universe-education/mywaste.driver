using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Geolocation;
using MyWasteDriver.DAL.DataObjects;
using Plugin.Geolocator;
using TK.CustomMap;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Work
{
	internal class PointInfoViewModel : BaseViewModel
	{
		public ICommand GoToSelectComplainTypeCommand => GetNavigateToCommand(AppPages.SelectComplainType);

		public ICommand OpenNavigatorToOrderPlaceCommand => MakeCommand(OpenNavigatorToOrderPlace);

		public ICommand CompleteOrderCommand => MakeCommand(CompleteOrder);

		private async void CompleteOrder()
		{
			State = PageState.Loading;
			await UserCoordinateAsync();
			State = PageState.Normal;
			var distance = GeoCalculator.GetDistance(_userPosition.Latitude, _userPosition.Longitude, OrderObject.Coordinates.Latitude,
				               OrderObject.Coordinates.Longitude) * 1.609;
			if (distance - 0.3 <= 0)
			{
				var _answer = await ShowQuestion("Внимание!", "Вы действительно хотите завершить заказ?", "Завершить заказ",
					"Вернуться обратно");
				if (_answer)
					//отправить на сервер 
					NavigateTo(AppPages.Points, NavigationMode.Root, newNavigationStack: true);
				else
					return;
			}
			else
			{
				ShowAlert("Для завершения заказа вы должны прибыть по указанному адресу.",
					$"В настоящее время в {distance.ToString("0.000")} км от указанной точки", "OK");
			}
		}

		private Position _userPosition;

		private async Task UserCoordinateAsync()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;
			var userPosition = await locator.GetPositionAsync(TimeSpan.FromSeconds(1));
			_userPosition = new Position(userPosition.Latitude, userPosition.Longitude);
		}

		private void OpenNavigatorToOrderPlace()
		{
			try
			{
				Device.OpenUri(_navigatorUri);
			}
			catch
			{
				Device.OpenUri(new Uri("market://details?id=ru.yandex.yandexnavi"));
			}
		}

		private Uri _navigatorUri;
		public string toolOrganization => _toolOrganization;
		string _toolOrganization;
		public string tutorial => _tutorial;
		string _tutorial;
		public string timerecom => _timerecom;
		string _timerecom;
		public string addres => _addres;
		string _addres;
		
		private AllOrders OrderObject { get; set; }
		

		public override async Task OnPageAppearing()
		{
			if (NavigationParams.TryGetValue("orderObject", out var x))
				OrderObject = (AllOrders) x;
			else
				State = PageState.Error;

			_navigatorUri = new Uri(
				"yandexnavi://build_route_on_map?lat_to=" + OrderObject.Coordinates.Latitude.ToString(CultureInfo.GetCultureInfo("en-US"))
				                                          + "&lon_to=" +
				                                          OrderObject.Coordinates.Longitude.ToString(CultureInfo.GetCultureInfo("en-US")));

			_toolOrganization =  OrderObject.OrganizationName ;
			_tutorial = OrderObject.TravelIntructions;
			//_timerecom = OrderObject.VisitingMode;
			_addres = OrderObject.OrderAdress;
			State = PageState.Normal;
		}
	}
}