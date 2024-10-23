namespace ArtfulAdventures.Web.Configuration;

using System.Drawing;

/// <summary>
///   This class is used to save the image to the local folder
/// </summary>
public static class SaveFileLocal
{
    /// <summary>
    ///  This method is used to save the image to the local folder
    /// </summary>
    /// <param name="filePath"> The path to the file </param>
    /// <param name="newImage"> The image to be saved </param>
    public static void SaveAsync(string filePath, Bitmap newImage)
    {
        using var stream = new MemoryStream();
        newImage.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

        var imageBytes = stream.ToArray();

        //Save the file to the local folder
        using var str = new FileStream(
            filePath, FileMode.Create, FileAccess.Write, FileShare.Write, 4096);
        str.Write(imageBytes, 0, imageBytes.Length);
    }

    /// <summary>
    ///  This method is used to resize the image
    /// </summary>
    /// <param name="file"> The image to be resized </param>
    /// <returns></returns>
    public static Bitmap ResizeImage(IFormFile file)
    {
        var image = Image.FromStream(file.OpenReadStream(), true, true);
        var newWidth = image.Width;
        var newHeight = image.Height;
        if (image.Width > 1000)
        {
            newWidth = (int)(image.Width * 0.5);
            newHeight = (int)(image.Height * 0.5);
        }

        var newImage = new Bitmap(image, new Size(newWidth, newHeight));
        return newImage;
    }
}