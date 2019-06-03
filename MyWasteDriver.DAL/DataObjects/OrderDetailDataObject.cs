using System.Collections.Generic;



namespace MyWasteDriver.DAL.DataObjects {
	public class OrderDetailDataObject {
		public string OrderId { get; set; }
		public string OrderData { get; set; }
		public string OrderTime { get; set; }
		public string OrderAdress { get; set; }
		public string Material { get; set; }
		public string Size { get; set; }
		public string Height { get; set; }
		public string Сomment { get; set; }
		public string FullName { get; set; }
		public TK.CustomMap.Position Coordinates { get; set; }

		public List<ImageUrl> AllImageUrl { get; set; }
	}

	public class ImageUrl { public string Url { get; set; } };

}
