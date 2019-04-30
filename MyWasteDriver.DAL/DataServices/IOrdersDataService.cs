using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataServices {
	public interface IOrdersDataService {
		Task<RequestResult<OrdersDataObject>> GetOrdersInfo(CancellationToken ctx);
		Task<RequestResult<OrderDetailDataObject>> GetOrderDetailInfoById(int id, CancellationToken ctx);
	}
}
