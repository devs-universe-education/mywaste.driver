using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;
using MyWasteDriver.UI.Pages;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using TK.CustomMap;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Work {
	class PointsViewModel : BaseViewModel
	{
		public PointsDataObject PointsObject
		{
			get => Get<PointsDataObject>();
			set => Set(value);
		}


		public ICommand CalloutClickedCommand => MakeCommand(GoToPointInfo);

		public ICommand OpenNavigatorToUnloadingPlaceCommand => MakeCommand(OpenNavigatorToUnloadingPlace);

		private void OpenNavigatorToUnloadingPlace()
		{
			try {
				Device.OpenUri(_navigatorUri);
			}
			catch {
				Device.OpenUri(new Uri("market://details?id=ru.yandex.yandexnavi"));
			}
		}

		private Uri _navigatorUri;

		private void GoToPointInfo()
		{
			var _dataToLoad = new AllOrders();
			foreach (var t in PointsObject.Orders)
			{
				if (_selectedPin.ID == t.OrderId) _dataToLoad = t;
			}
			var Data = new Dictionary<string, object>()
			{
				{"orderObject", _dataToLoad}
			};
			NavigateTo(AppPages.PointInfo, navParams: Data);
		}

		public ObservableCollection<TKCustomMapPin> OrdersPins
		{
			get { return _ordersPins; }
			set { _ordersPins = value; }
		}
		private ObservableCollection<TKCustomMapPin> _ordersPins;

		public TKCustomMapPin SelectedPin
		{
			get { return _selectedPin; }
			set { _selectedPin = value; }
		}
		private TKCustomMapPin _selectedPin;

		public string UnloadingAddress
		{
			get { return _unloadingAddress; }
			set { _unloadingAddress = value; }
		}
		private string _unloadingAddress;

		public string CompanyName {
			get { return _companyName; }
			set { _companyName = value; }
		}
		private string _companyName;

		
		public MapSpan OrderPosition => _orderPosition;
		private MapSpan _orderPosition;

		public DateTime CurrentDate => DateTime.Now; // исправить


		public override async Task OnPageAppearing()
		{
			State = PageState.Loading;
			await CheckPermissionsAsync();
			var result = await DataServices.Work.GetPointsDataObject(CancellationToken);

			if (result.IsValid)
			{
				PointsObject = result.Data;
				_ordersPins = new ObservableCollection<TKCustomMapPin>();

				foreach (var t in PointsObject.Orders)
				{
					var o = new TKCustomMapPin()
					{
						Position = new Position(t.Coordinates.Latitude, t.Coordinates.Longitude),
						Title = t.OrganizationName,
						ShowCallout = true,
						Subtitle = t.OrderAdress,
						IsCalloutClickable = true,
						ID = t.OrderId

					};
					o.DefaultPinColor = t.CompletedOrNot ? Color.Green : Color.SlateGray;
					_ordersPins.Add(o);
				}

				var unlPlaceObj = new TKCustomMapPin()
				{
                    Position = new Position(PointsObject.UnloadingPlace.Coordinates.Latitude, PointsObject.UnloadingPlace.Coordinates.Longitude),
                    Title = PointsObject.UnloadingPlace.CompanyName,
                    ShowCallout = true,
                    Subtitle = PointsObject.UnloadingPlace.UnloadingAddress,
                    //IsCalloutClickable = true,
                    //ID
                    Image = "flag.png" // не работает 
				};
				_ordersPins.Add(unlPlaceObj);

				_navigatorUri = new Uri("yandexnavi://build_route_on_map?lat_to=" + PointsObject.UnloadingPlace.Coordinates.Latitude.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US"))
				                                                                  + "&lon_to=" + PointsObject.UnloadingPlace.Coordinates.Longitude.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));

				_orderPosition = new MapSpan(new Position(51.712468, 39.181733), 1, 1); // исправить
				_companyName = PointsObject.UnloadingPlace.CompanyName;
				_unloadingAddress = PointsObject.UnloadingPlace.UnloadingAddress;
				State = PageState.Normal;
			}
		}

        // Временный вариант
		async Task CheckPermissionsAsync()
		{
			var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
			var locationStaus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

			if (storageStatus == PermissionStatus.Denied || storageStatus == PermissionStatus.Disabled)
			{
				storageStatus = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage))[Permission.Storage];
			}

			if (locationStaus == PermissionStatus.Denied || locationStaus == PermissionStatus.Disabled)
			{
				locationStaus = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location))[Permission.Location];
			}
		}
	}
}
