using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataObjects.Login;

namespace MyWasteDriver.DAL.DataServices.Mock {
	class MockCommonDataService : BaseMockDataService, ICommanDataService {

		public Task<RequestResult<UserInfoObject>> GetUserInfoDataObject(string userPhoneNumber, string userPassword, CancellationToken ctx) {
			return GetMockData<UserInfoObject>("MyWasteDriver.DAL.Resources.Common.UserInfoObject.json");
		}
		public Task<RequestResult<UserPhone>> RequestPassword(string userPhoneNumber, CancellationToken ctx) {
			return GetMockData<UserPhone>("MyWasteDriver.DAL.Resources.Common.UserInfoObject.json");
		}
	}
}