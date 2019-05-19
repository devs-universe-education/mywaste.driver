using System.Collections.ObjectModel;
using Xamarin.Forms.Maps;

namespace MyWasteDriver.DAL.DataObjects {
	public class CurrentOrderDataObject {

		public string OrderId { get; set; }
		public string OrderData { get; set; }
		public string OrderTime { get; set; }
		public string OrderAdress { get; set; }
		public string Material { get; set; }
		public string Сomment { get; set; }
		public string FullName { get; set; }
		public Position Coordinates { get; set; }
	}

}
