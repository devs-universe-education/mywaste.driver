using System.Threading;
using System.Threading.Tasks;
using MyWasteDriver.DAL.DataObjects;

namespace MyWasteDriver.DAL.DataServices
{
	public interface ILoginDataService
	{
		Task<RequestResult<LoginDataObject>> PerformValidation(CancellationToken ctx);
	}
	
}