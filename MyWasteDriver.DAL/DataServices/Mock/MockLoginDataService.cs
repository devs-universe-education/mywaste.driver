using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataServices.Mock {
	class MockLoginDataService :BaseMockDataService, ILoginDataService {
		public Task<RequestResult<LoginDataObject>> PerformValidation(CancellationToken ctx, string login, string password)
		{
			return GetMockData<LoginDataObject>("MyWasteDriver.DAL.Resources.Mock.Login.LoginDataObject.json");
		}
	}
}
