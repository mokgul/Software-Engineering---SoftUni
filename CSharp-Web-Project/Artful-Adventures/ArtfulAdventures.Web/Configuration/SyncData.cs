namespace ArtfulAdventures.Web.Configuration;

/// <summary>
///  This class is used to sync the data from the FTP server
/// </summary>
public static class SyncData
{
    /// <summary>
    ///  This method is used to sync the data from the FTP server
    /// </summary>
    public static async Task ExecuteAsync()
    {
        while (true)
        {
            await DownloadFromFtpServer.DownloadData();
            await Task.Delay(TimeSpan.FromMinutes(1));
        }
    }
}