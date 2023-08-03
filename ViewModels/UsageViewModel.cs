using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using System.Collections.ObjectModel;

namespace ExploreCity.ViewModels
{
    public partial class UsageViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<PinModel> pinModel;

        public UsageViewModel()
        {
            pinModel = new ObservableCollection<PinModel>();
        }

        [RelayCommand]
        public async Task OnCameraClicked(CancellationToken cancellationToken)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                photo.FileName = DateTime.Now.ToString("dd-MM-yyyy H:mm ss") + ".jpg";
                if (photo != null)
                {
                    string localFilePath = Path.Combine(FileSystem.Current.CacheDirectory, photo.FileName); //localFilePath va a ser igual a la combinacion del directorio del cache con el nombre del archivo
                    using Stream source = await photo.OpenReadAsync();
                    using FileStream fileStream = File.OpenWrite(localFilePath);

                    await source.CopyToAsync(fileStream);
                }
            }
        }
    }
}
