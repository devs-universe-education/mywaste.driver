using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataServices.Mock {
	class MockWorkDataService: BaseMockDataService, IWorkDataService {
		public Task<RequestResult<PointsDataObject>> GetPointsDataObject(CancellationToken ctx) {
			return GetMockData<PointsDataObject>("MyWasteDriver.DAL.Resources.Mock.Work.PointsDataObject.json");
		}
	}
}

