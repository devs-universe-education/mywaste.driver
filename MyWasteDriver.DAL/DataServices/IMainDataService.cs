using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataServices {
	public interface IMainDataService {
		Task<RequestResult<SampleDataObject>> GetSampleDataObject(CancellationToken ctx);
	}
}

