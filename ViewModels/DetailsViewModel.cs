using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using ExploreCity.Services;
using Microsoft.Maui.Controls.Maps;

namespace ExploreCity.ViewModels
{
    [QueryProperty(nameof(PinData), "PinData")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        public PinModel pinData;

        private IPinService pinService;
        public DetailsViewModel(IPinService _pinService)
        {
            pinService = _pinService;
            pinData = new PinModel();
        }

        [RelayCommand]
        public async Task OnCameraClicked()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    photo.FileName = DateTime.Now.ToString("dd-MM-yyyy H:mm ss") + ".jpg";
                    PinData.ImageFullPath = Path.Combine(FileSystem.Current.AppDataDirectory, photo.FileName);

                    string localFilePath = Path.Combine(FileSystem.Current.AppDataDirectory, photo.FileName);
                    using Stream source = await photo.OpenReadAsync();
                    using FileStream fileStream = File.OpenWrite(localFilePath);

                    await source.CopyToAsync(fileStream);
                    await pinService.UpdatePinAsync(PinData);
                }
            }
        }

        [RelayCommand]
        public async Task SavePinAsync()
        {
            await pinService.UpdatePinAsync(PinData);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async void DeletePinAsync()
        {
            var result = await pinService.DeletePinAsync(PinData);
            if (result > 0)
            {
                await Shell.Current.DisplayAlert("Mensaje", "Marca eliminada", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Mensaje", "La marca no fue eliminada", "OK"); 
            }
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        public async Task ShareImage()
        {
            string imagePath = PinData.ImageFullPath;

            await Share.Default.RequestAsync(new ShareFileRequest
            {
                Title = "Compartir imagén del marcador",
                File = new ShareFile(imagePath)
            });
        }
    }
}
