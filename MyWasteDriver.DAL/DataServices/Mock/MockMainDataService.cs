using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataServices.Mock {
	class MockMainDataService: BaseMockDataService, IMainDataService {
		public Task<RequestResult<SampleDataObject>> GetSampleDataObject(CancellationToken ctx) {
			return GetMockData<SampleDataObject>("MyWasteDriver.DAL.Resources.Mock.Main.SampleDataObject.json");
		}
	}
}

