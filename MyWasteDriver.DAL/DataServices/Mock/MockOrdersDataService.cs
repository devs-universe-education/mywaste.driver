using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataServices.Mock {
	class MockOrdersDataService : BaseMockDataService, IOrdersDataService {
		public Task<RequestResult<OrdersDataObject>> GetOrdersInfo(CancellationToken ctx) {
			return GetMockData<OrdersDataObject>("MyWasteDriver.DAL.Resources.Mock.Work.OrdersDataObject.json");
		}

		public Task<RequestResult<OrderDetailDataObject>> GetOrderDetailInfoById(int id, CancellationToken ctx) {
			return GetMockData<OrderDetailDataObject>("MyWasteDriver.DAL.Resources.Mock.Work.OrderDetailInfoDataObject.json"); 
		}

		public	Task<RequestResult<CurrentOrderDataObject>> GetCurrentOrderInfoById(int id, CancellationToken ctx) {
			return GetMockData<CurrentOrderDataObject>("MyWasteDriver.DAL.Resources.Mock.Work.CurrentOrderInfoDataObject.json");
		}
	}
}
