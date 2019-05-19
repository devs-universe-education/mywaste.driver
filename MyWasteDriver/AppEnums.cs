namespace MyWasteDriver
{
	public enum AppPages {
		Main,
		Login,
		Orders,
		OrderInfo,
		CurrentOrder,
		CompleteOrder
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
		Map,
		AddField

	}
}

