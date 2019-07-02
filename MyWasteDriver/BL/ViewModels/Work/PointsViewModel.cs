using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		private TKCustomMapPin _selectedPin;

		public TKCustomMapPin SelectedPin
		{
			get { return _selectedPin; }
			set { _selectedPin = value; }

		}

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
