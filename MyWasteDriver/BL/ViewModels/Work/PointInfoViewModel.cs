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

		public Dictionary<string, object> _dataToLoad;

		public ICommand GoToSelectComplainTypeCommand => GetNavigateToCommand(AppPages.SelectComplainType);
		public ICommand GoToReport => GetNavigateToCommand(AppPages.ReportComplain);
		public override async Task OnPageAppearing()
		{

			if (NavigationParams.TryGetValue("orderObject", out var x))
			{
				var v = x;
			}
			State = PageState.Normal;

		}
	}
}
