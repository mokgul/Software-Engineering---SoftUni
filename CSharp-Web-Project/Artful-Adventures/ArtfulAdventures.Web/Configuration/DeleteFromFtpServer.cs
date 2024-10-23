namespace ArtfulAdventures.Web.Configuration;

/// <summary>
///   This class is used to delete files from the FTP server.
/// </summary>
public static class DeleteFromFtpServer
{
    /// <summary>
    ///  This method deletes a file from the FTP server.
    /// </summary>
    /// <param name="pathToDelete"></param>
    public static async Task DeleteFile(string pathToDelete)
    {
        var client = FtpClientConfiguration.GetFtpClient();
        var listing = await client.GetNameListing();
        var ftpPath = "/" + Path.GetFileName(pathToDelete);
        if(!listing.Contains(ftpPath))
        {
            return;
        }
        await client.Connect();
        await client.DeleteFile("/" + Path.GetFileName(ftpPath));
        await client.Disconnect();
    }
}

