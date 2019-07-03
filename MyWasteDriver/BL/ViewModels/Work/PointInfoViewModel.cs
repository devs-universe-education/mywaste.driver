using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataServices;
using TK.CustomMap;

namespace MyWasteDriver.BL.ViewModels.Work {
	class PointInfoViewModel: BaseViewModel
	{


		public ICommand GoToSelectComplainTypeCommand => GetNavigateToCommand(AppPages.SelectComplainType);

		AllOrders OrderObject
		{
			get { return _orderObject; }
			set { _orderObject = value; }
		}

		private AllOrders _orderObject;


		public override async Task OnPageAppearing()
		{

			if (NavigationParams.TryGetValue("orderObject", out var x))
			{
				var t = typeof(AppPages);
			//	_orderObject = Convert.ChangeType(x, t);
			}

			_orderObject = ((AllOrders) x);

			State = PageState.Normal;

		}
	}
}
