
using System.Collections.Generic;


namespace MyWasteDriver.DAL.DataObjects {
	public class OrdersDataObject  {
		public List<OrderDataObject> Orders { get; set; }
	}

	public class OrderDataObject {

		public string OrderData { get; set; }
		public string OrderTime { get; set; } 
		public string OrderAdress { get; set; }
		public string Material { get; set; }
		public string Size { get; set; }
		public string Height { get; set; }

	}
}
