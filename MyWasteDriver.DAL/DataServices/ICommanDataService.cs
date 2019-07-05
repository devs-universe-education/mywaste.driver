using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using MyWasteDriver.DAL.DataObjects.Login;

namespace MyWasteDriver.DAL.DataServices {
	public interface ICommanDataService {
		Task<RequestResult<UserInfoObject>> GetUserInfoDataObject(string userPhoneNumber, string userPassword, CancellationToken ctx);
		Task<RequestResult<UserPhone>> RequestPassword(string userPhone, CancellationToken ctx);
	}
}