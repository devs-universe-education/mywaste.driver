using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using TK.CustomMap;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Work
{
	internal class PointsViewModel : BaseViewModel
	{
		public PointsDataObject PointsObject
		{
			get => Get<PointsDataObject>();
			set => Set(value);
		}

		public string TexToTitle => _texToTitle;
		private string _texToTitle;
		public ICommand CalloutClickedCommand => MakeCommand(GoToPointInfo);

		public ICommand OpenNavigatorToUnloadingPlaceCommand => MakeCommand(OpenNavigatorToUnloadingPlace);

		private void OpenNavigatorToUnloadingPlace()
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

		public void GoToPointInfo()
		{
			var _dataToLoad = new AllOrders();
			foreach (var t in PointsObject.Orders)
				if (_selectedPin.ID == t.OrderId)
					_dataToLoad = t;
			var Data = new Dictionary<string, object>
			{
				{"orderObject", _dataToLoad}
			};
			NavigateTo(AppPages.PointInfo, navParams: Data);
		}

		public ObservableCollection<TKCustomMapPin> OrdersPins { get; set; }

		public TKCustomMapPin SelectedPin
		{
			set => _selectedPin = value;
		}

		private TKCustomMapPin _selectedPin;

		public string UnloadingAddress { get; set; }

		public string CompanyName { get; set; }


		public MapSpan OrderPosition { get; private set; }

		public DateTime CurrentDate => DateTime.Now; // исправить


		public override async Task OnPageAppearing()
		{
			State = PageState.Loading;
			await CheckPermissionsAsync();
			var result = await DataServices.Work.GetPointsDataObject(CancellationToken);

			if (result.IsValid)
			{
				PointsObject = result.Data;
				OrdersPins = new ObservableCollection<TKCustomMapPin>();

				foreach (var t in PointsObject.Orders)
				{
					var o = new TKCustomMapPin
					{
						Position = new Position(t.Coordinates.Latitude, t.Coordinates.Longitude),
						Title = t.OrganizationName,
						ShowCallout = true,
						Subtitle = t.OrderAdress,
						IsCalloutClickable = true,
						ID = t.OrderId
					};
					o.DefaultPinColor = t.CompletedOrNot ? Color.Green : Color.SlateGray;
					OrdersPins.Add(o);
				}

				var unlPlaceObj = new TKCustomMapPin
				{
					Position = new Position(PointsObject.UnloadingPlace.Coordinates.Latitude,
						PointsObject.UnloadingPlace.Coordinates.Longitude),
					Title = PointsObject.UnloadingPlace.CompanyName,
					ShowCallout = true,
					Subtitle = PointsObject.UnloadingPlace.UnloadingAddress,
					DefaultPinColor = Color.Red
				};
				OrdersPins.Add(unlPlaceObj);

				_navigatorUri = new Uri(
					"yandexnavi://build_route_on_map?lat_to=" + PointsObject.UnloadingPlace.Coordinates.Latitude.ToString(
						                                          CultureInfo.GetCultureInfo("en-US"))
					                                          + "&lon_to=" +
					                                          PointsObject.UnloadingPlace.Coordinates.Longitude.ToString(
						                                          CultureInfo.GetCultureInfo("en-US")));

				OrderPosition = new MapSpan(new Position(51.712468, 39.181733), 1, 1); // исправит
				_texToTitle = "Место выгрузки: " + PointsObject.UnloadingPlace.UnloadingAddress + ", " + PointsObject.UnloadingPlace.CompanyName;
				State = PageState.Normal;
			}
		}

		// Временный вариант
		private async Task CheckPermissionsAsync()
		{
			var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);
			var locationStaus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);

			if (storageStatus == PermissionStatus.Denied || storageStatus == PermissionStatus.Disabled)
				storageStatus = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage))[Permission.Storage];

			if (locationStaus == PermissionStatus.Denied || locationStaus == PermissionStatus.Disabled)
				locationStaus = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location))[Permission.Location];
		}
	}
}