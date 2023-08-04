using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Models;
using ExploreCity.Views;
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
        string _label;

        [ObservableProperty]
        PinModel _pinModel;

        [ObservableProperty]
        ObservableCollection<PinModel> _locations;

        public UsageViewModel()
        {
            _pinModel = new PinModel();
            _locations = new ObservableCollection<PinModel>();
            _coordinates = new Location(19.3877863855499, -70.5287242680788);
            _address = "address test";
            _label = "label test";
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

        [RelayCommand]
        public async Task SetNewPin()
        {
            UsagePage usagePage = new UsagePage(this);
            var sender = usagePage.GetSender();
            var mapClicked = usagePage.GetMapClickedEventArgs();

            usagePage.OnMapClicked(sender, mapClicked);
            Coordinates = UsagePage.tappedLocation;
        }
    }
}
