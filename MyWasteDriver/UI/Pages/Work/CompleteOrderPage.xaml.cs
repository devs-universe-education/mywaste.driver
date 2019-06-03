
using Xamarin.Forms;

namespace MyWasteDriver.UI.Pages.Work
{

	public partial class CompleteOrderPage : BasePage
	{
		public CompleteOrderPage ()
		{
			InitializeComponent ();
			NavigationPage.SetHasNavigationBar(this, false);
		
		}

		private void Ckliked(object sender, System.EventArgs e) {
			
		}

		private void FocusGlass(object sender, FocusEventArgs e) {
			var i = 0;
			if (i == (i % 2) * 2) {
				GlassEntr.IsVisible = true;
			}
			else
			GlassEntr.IsVisible = false;
		}

		private void FocusPlastik(object sender, FocusEventArgs e) {
			PlastikEntr.IsVisible = true;
		}

		private void FocusPaper(object sender, FocusEventArgs e) {
			PaperEntr.IsVisible = true;
		}
	}
}