namespace MyWasteDriver
{
	public enum AppPages {
		Login,
		Main,
		Menu,
		Points,
		PointInfo,
		SelectComplainType,
		ReportComplain
	}

	public enum NavigationMode {
		Normal,
		Modal,
		Root,
		Custom
	}

	public enum PageState {
		Clean,
		Loading,
		Normal,
		NoData,
		Error,
		NoInternet,
		EnterPhone,
		EnterPassword,
		Entry

	}
}

