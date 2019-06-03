

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Work {
	class CompleteOrderViewModel : BaseViewModel {
		public ICommand GoToAddFieldStateCommand => MakeCommand(ShowPageStateAddField);

		public List<MaterialС> MaterialList { get { return _materialList; } set { _materialList = value; } }

		public List<MaterialС> _materialList = PickerService.GetMaterials().OrderBy(c => c.Value).ToList();

		private void ShowPageStateAddField() {
			State = PageState.AddField;
		}

		public override async Task OnPageAppearing() {
			State = PageState.Normal;
		}
	}
	public class MaterialС {
		public int Key { get; set; }
		public object Value { get; set; }

	}

	public class PickerService {
		public static List<MaterialС> GetMaterials() {
			var materials = new List<MaterialС> {
				new MaterialС() {Key = 1, Value = "Пластик"},
				new MaterialС() {Key = 1, Value = "Бумага"}
			};
			return materials;
		}
	}
}

