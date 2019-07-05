using System;
using System.Collections.Generic;
using System.Text;

namespace MyWasteDriver.DAL.DataObjects.Login {
	public class UserInfoObject {
		public string UserFullName { get; set; }
		public string UserPhoneNumber { get; set; }
		public string MachineModel { get; set; }
		public string StateMachineNumber { get; set; }
		public string CompanyName { get; set; }
		public string CompanyAddress { get; set; }
		public string CompanyPhoneNumber { get; set; }
	}

	public class UserPhone {
		public bool AvailableOrNot { get; set; }
	}
}