using System;

namespace MyWasteDriver.DAL.DataServices
{
	public static class DataServices {
		public static IOrdersDataService Work { get; private set; }
		
		public static IMainDataService Main { get; private set; }

		public static void Init(bool isMock) {
			if (isMock) {
				Work = new Mock.MockOrdersDataService();
				Main = new Mock.MockMainDataService();
			}
			else {
				throw new NotImplementedException("Online Data Services not implemented");
			}
		}


	}
}

