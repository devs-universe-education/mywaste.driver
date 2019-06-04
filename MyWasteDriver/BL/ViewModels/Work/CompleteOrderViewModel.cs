

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyWasteDriver.BL.ViewModels.Work {
	class CompleteOrderViewModel : BaseViewModel {
		public ICommand GoToAddFieldStateCommand => MakeCommand(ShowPageStateAddField);
		public ICommand GoToCompleteOrderPage => MakeCommand(ShowCompleteOrderPage);
		public List<OrderMaterial> OrdersMaterials { get; set; } = new List<OrderMaterial>();
		


		public object _selectedMateial;
		public object SelectedMaterial { get { return _selectedMateial; } set { _selectedMateial = value; } }
		public List<MaterialС> MaterialList { get { return _materialList; } set { _materialList = value; } }

		public string _weight;
		public string Weight { get { return _weight; } set { _weight = value; } }

		public List<MaterialС> _materialList = PickerService.GetMaterials().OrderBy(c => c.Value).ToList();

		void ShowCompleteOrderPage() {
			OrdersMaterials = new List<OrderMaterial>(OrdersMaterials) {
				new OrderMaterial {Material = SelectedMaterial, Weight = Weight}
			};

			State = PageState.Normal;

		}

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

	public class OrderMaterial {

		public object Material { get; set; }
		public object Weight { get; set; }
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

