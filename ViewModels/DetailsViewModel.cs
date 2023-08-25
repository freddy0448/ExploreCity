using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExploreCity.Core;
using ExploreCity.Models;
using ExploreCity.Services;

namespace ExploreCity.ViewModels
{
    [QueryProperty(nameof(PinData), "PinData")]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        public PinModel pinData;

        [ObservableProperty]
        public bool isShareVisible;

        FileResult photo;

        private IPinService pinService;
        public DetailsViewModel(IPinService _pinService)
        {
            pinService = _pinService;
            pinData = new PinModel();
        }

        [RelayCommand]
        public async Task CameraActions()
        {
            photo = await GraphicsHandler.TakePicture(photo);
            photo = await GraphicsHandler.SavePicture(photo);

            PinData.ImageFullPath = Path.Combine(FileSystem.Current.AppDataDirectory, photo.FileName);

            await pinService.UpdatePinAsync(PinData);            
        }

        [RelayCommand]
        public async Task SavePinAsync()
        {
            await pinService.UpdatePinAsync(PinData);

            if (string.IsNullOrEmpty(PinData.LabelDescription))
                await Shell.Current.DisplayAlert("Mensaje", "El campo ' Título ' no puede estar vacio", "OK");
            else
            {
                await Shell.Current.DisplayAlert("Mensaje", "Cambios guardados exitosamente", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        [RelayCommand]
        public async void DeletePinAsync()
        {
            bool firstResult = await Shell.Current.DisplayAlert("Mensaje",  "Está seguro que desea eliminar la marca?", "SI", "NO");
            if (firstResult)
            {
                var result = await pinService.DeletePinAsync(PinData);
                if (result > 0)
                {
                    await Shell.Current.DisplayAlert("Mensaje", "Marca eliminada", "OK");
                    await Shell.Current.GoToAsync("..");
                }
                else
                {
                    await Shell.Current.DisplayAlert("Mensaje", "La marca no fue eliminada", "OK");
                }
            }
            else return;
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
