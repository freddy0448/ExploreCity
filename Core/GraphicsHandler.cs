namespace ExploreCity.Core
{
    public static class GraphicsHandler
    {
        public static async Task<FileResult> TakePicture(FileResult photo)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                photo = await MediaPicker.Default.CapturePhotoAsync();
                return photo;

            }
            else return null;
        }

        public static async Task<FileResult> SavePicture(FileResult photo)
        {
            if (photo != null)
            {
                photo.FileName = DateTime.Now.ToString("dd-MM-yyyy H:mm ss") + ".jpg";

                string localFilePath = Path.Combine(FileSystem.Current.AppDataDirectory, photo.FileName);
                using Stream source = await photo.OpenReadAsync();
                using FileStream fileStream = File.OpenWrite(localFilePath);

                await source.CopyToAsync(fileStream);

            }
            return photo;
        }
    }
}