using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using ExploreCity.Services;
using Microsoft.Maui.Controls.Maps;

namespace ExploreCity.ViewModels
{
    [QueryProperty(nameof(Pin), "Pin")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        public PinModel pinData;

        [ObservableProperty]
        public Pin pin;

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
                    PinData.ImageFullPath = "/data/user/0/com.companyname.explorecity/cache/" + photo.FileName;

                    string localFilePath = Path.Combine(FileSystem.Current.CacheDirectory, photo.FileName);
                    using Stream source = await photo.OpenReadAsync();
                    using FileStream fileStream = File.OpenWrite(localFilePath);

                    await source.CopyToAsync(fileStream);
                }
            }
        }

        [RelayCommand]
        public async Task SavePinAsync()
        {
            PinData.Address = Pin.Address;
            PinData.LabelDescription = Pin.Label;
            await pinService.UpdatePinAsync(PinData);
        }
    }
}
