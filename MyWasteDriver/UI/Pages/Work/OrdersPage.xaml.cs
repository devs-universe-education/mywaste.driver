using Xamarin.Forms;

namespace MyWasteDriver.UI.Pages.Work
{
	
	public partial class OrdersPage : BasePage
	{
		protected override bool OnBackButtonPressed() {
			
			return true;
		}

		public OrdersPage ()
		{
			
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
			
		}
		
	}
}