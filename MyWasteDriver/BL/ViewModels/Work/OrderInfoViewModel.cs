using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;

using Xamarin.Forms.Maps;

namespace MyWasteDriver.BL.ViewModels.Work {
	class OrderInfoViewModel : BaseViewModel {

		public OrderDetailDataObject OrderInfoObject {

			get => Get<OrderDetailDataObject>();
			set => Set(value);


		}

		public ObservableCollection<Pin> _locations;
		public Position _userPosition;

		public ObservableCollection<Pin> Locations { get { return _locations; } set { _locations = value; } }
		public Position UserPosition { get { return _userPosition; } set { _userPosition = value; OnPropertyChanged(); } }
		

		public override async Task OnPageAppearing() {

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

			_userPosition = OrderInfoObject.Coordinates;
			_locations = new ObservableCollection<Pin> {

				new Pin{Position = OrderInfoObject.Coordinates, Type = PinType.Generic, Label = OrderInfoObject.Material, Address = OrderInfoObject.OrderAdress}
			};

			State = PageState.Map;
		}
		void ShowPageStateNormal() {
			State = PageState.Normal;
		}
	}
}

