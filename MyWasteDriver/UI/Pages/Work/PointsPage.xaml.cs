using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyWasteDriver.UI.Pages.Work {
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PointsPage: BasePage {
		[Obsolete]
		public PointsPage() {
			InitializeComponent();
			var tb = new ToolbarItem {
				Text="16 июля 2019",
				Order= ToolbarItemOrder.Primary,
				Priority = 0,
				
			};
			var tb2 = new ToolbarItem {
				Order = ToolbarItemOrder.Primary,
				Priority = 2,
				Icon = new FileImageSource {
					File = "replay.png"
				}
			};
			ToolbarItems.Add(tb);
			ToolbarItems.Add(tb2);
		}
	}
}