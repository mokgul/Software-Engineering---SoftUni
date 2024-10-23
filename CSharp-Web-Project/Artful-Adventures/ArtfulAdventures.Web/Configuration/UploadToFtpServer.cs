namespace ArtfulAdventures.Web.Configuration;

using FluentFTP;

/// <summary>
///   This class is used to upload files to the FTP server.
/// </summary>
public static class UploadToFtpServer
{
    /// <summary>
    ///  This method uploads a file to the FTP server.
    /// </summary>
    /// <param name="fileName"> The name of the file to be uploaded. </param>
    /// <param name="filePath"> The path to the file to be uploaded. </param>
    public static async Task UploadFile(string fileName, string filePath)
    {
        var client = FtpClientConfiguration.GetFtpClient();

        await client.Connect();
        await client.UploadFile(filePath, fileName);
        await client.Disconnect();
    }
}

