using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Akavache;
using MyWasteDriver.DAL.DataObjects;
using MyWasteDriver.DAL.DataObjects.Login;
using MyWasteDriver.DAL.DataServices;
using MyWasteDriver.UI;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Common {
	internal class LoginViewModel : BaseViewModel {
		public ICommand GoToPointsPageCommand => MakeCommand(GoToPoints);

		public string UserLogin { get; set; }
		public string UserPassword { get; }

		private async void GoToPoints() {
			State = PageState.Loading;


			var userData = await DataServices.Comman.GetUserInfoDataObject(UserLogin, UserPassword, CancellationToken);

			if (userData.IsValid) {
				await BlobCache.UserAccount.InsertObject("user", userData.Data);



				NavigationService.Instance.SetMainMasterDetailPage(AppPages.Menu, AppPages.Points);
			}
		}

		public ICommand GoToPageStateLogin => MakeCommand(GoToLogin);

		private async void GoToLogin() {
			State = PageState.EnterPassword;
		}

		public override async Task OnPageAppearing() {
			bool _checkLoginAsync;

			try {
				var userInfo = await BlobCache.UserAccount.GetObject<UserInfoObject>("user");
				if (userInfo.UserPhoneNumber == "" || userInfo.UserPhoneNumber == null)
					_checkLoginAsync = false;
				else
					_checkLoginAsync = true;
			}
			catch {
				_checkLoginAsync = false;
			}

			if (_checkLoginAsync)
				NavigationService.Instance.SetMainMasterDetailPage(AppPages.Menu, AppPages.Points);
			else
				State = PageState.EnterPhone;
		}
	}

	public class MaskedBehavior : Behavior<Entry> {
		private string _mask = "";

		public string Mask {
			get => _mask;
			set {
				_mask = value;
				SetPositions();
			}
		}

		protected override void OnAttachedTo(Entry entry) {
			entry.TextChanged += OnEntryTextChanged;
			base.OnAttachedTo(entry);
		}

		protected override void OnDetachingFrom(Entry entry) {
			entry.TextChanged -= OnEntryTextChanged;
			base.OnDetachingFrom(entry);
		}

		private IDictionary<int, char> _positions;

		private void SetPositions() {
			if (string.IsNullOrEmpty(Mask)) {
				_positions = null;
				return;
			}

			var list = new Dictionary<int, char>();
			for (var i = 0; i < Mask.Length; i++)
				if (Mask[i] != 'X')
					list.Add(i, Mask[i]);

			_positions = list;
		}

		private void OnEntryTextChanged(object sender, TextChangedEventArgs args) {
			var entry = sender as Entry;

			var text = entry.Text;

			if (string.IsNullOrWhiteSpace(text) || _positions == null)
				return;

			if (text.Length > _mask.Length) {
				entry.Text = text.Remove(text.Length - 1);
				return;
			}

			foreach (var position in _positions)
				if (text.Length >= position.Key + 1) {
					var value = position.Value.ToString();
					if (text.Substring(position.Key, 1) != value)
						text = text.Insert(position.Key, value);
				}

			if (entry.Text != text)
				entry.Text = text;
		}
	}
}