using ExploreCity.ViewModels;

namespace ExploreCity.Views;

public partial class UsagePage : ContentPage
{
	public UsagePage(UsageViewModel usageViewModel)
	{
		InitializeComponent();
		BindingContext = usageViewModel;
	}

    private async void OnCameraClicked(object sender, EventArgs e)
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
            if (photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName); //localFilePath va a ser igual a la combinacion del directorio del cache con el nombre del archivo
                using Stream source = await photo.OpenReadAsync();
                using FileStream fileStream = File.OpenWrite(localFilePath);
                
                await source.CopyToAsync(fileStream);
            }
        }
    }
}