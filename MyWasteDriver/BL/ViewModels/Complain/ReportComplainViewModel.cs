using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using Plugin.Media.Abstractions;
using TK.CustomMap;
using Xamarin.Forms;

namespace MyWasteDriver.BL.ViewModels.Complain {
	class ReportComplainViewModel : BaseViewModel {

		public MapSpan Position { get; private set; }


		public ICommand ReturnToPoints => GetNavigateToCommand(AppPages.Points);

		public ICommand MakePhotoCommand => MakeCommand(MakePhoto);

		private Image img = new Image();

		public string PhotoB
		{
			get => Get<string>();
			set => Set(value);
		} 

		private async void MakePhoto()
		{
			if (CrossMedia.Current.IsCameraAvailable && CrossMedia.Current.IsTakePhotoSupported) {
				var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions {
					SaveToAlbum = true,
					Directory = "Sample",
					Name = $"{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.jpg"
				});

				if (file == null)
					return;

				PhotoB = file.Path;
			}
		}



		public override async Task OnPageAppearing()
		{
			PhotoB = "photo.jpg";
			State = PageState.Normal;
			Position = new MapSpan(new Position(51.712468, 39.181733), 0.2, 0.2);
		}
	}
}
