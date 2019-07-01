using System.Collections.Generic;
using OrderKingCoreDemo.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataObjects {
	public class SampleDataObject
	{
		public List<AllOrders> Orders { get; set; }
	}

	public class AllOrders
	{
		public string OrderAdress { get; set; }
		public PositionObject Coordinates { get; set; }
	}

	
}

