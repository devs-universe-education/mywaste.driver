using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataServices {
	public interface IWorkDataService {
		Task<RequestResult<PointsDataObject>> GetPointsDataObject(CancellationToken ctx);
	}
}

