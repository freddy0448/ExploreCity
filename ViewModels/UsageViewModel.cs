using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using ExploreCity.Views;
using Microsoft.Maui.Controls.Maps;
using System.Collections.ObjectModel;

namespace ExploreCity.ViewModels
{
    public partial class UsageViewModel : ObservableObject
    {
        [ObservableProperty]
        Location _coordinates;

        [ObservableProperty]
        string _address;

        [ObservableProperty]
        string _labelDescription;

        [ObservableProperty]
        PinModel _pinModel;

        [ObservableProperty]
        ObservableCollection<PinModel> _locations;

        public UsageViewModel()
        {
            _pinModel = new PinModel();
            _locations = new ObservableCollection<PinModel>();
        }

        [RelayCommand]
        public async Task OnCameraClicked()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                photo.FileName = DateTime.Now.ToString("dd-MM-yyyy H:mm ss") + ".jpg";
                if (photo != null)
                {
                    string localFilePath = Path.Combine(FileSystem.Current.CacheDirectory, photo.FileName);
                    using Stream source = await photo.OpenReadAsync();
                    using FileStream fileStream = File.OpenWrite(localFilePath);

                    await source.CopyToAsync(fileStream);
                }
            }
        }

    }
}
 