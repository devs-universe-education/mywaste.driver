using System;

namespace MyWasteDriver.DAL.DataServices
{
	public static class DataServices {
		public static IWorkDataService Work { get; private set; }

		public static void Init(bool isMock) {
			if (isMock) {
				Work = new Mock.MockWorkDataService();
			}
			else {
				throw new NotImplementedException("Online Data Services not implemented");
			}
		}
	}
}

