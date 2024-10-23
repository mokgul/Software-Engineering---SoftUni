namespace ArtfulAdventures.Web.Configuration;

using FluentFTP;


/// <summary>
///   This class is used to download data from the FTP server.
/// </summary>
public static class DownloadFromFtpServer
{
    /// <summary>
    ///  This method downloads data from the FTP server.
    /// </summary>
    public static async Task DownloadData()
    {
        var localPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        var localFiles = Directory.GetFiles(@"wwwroot\images").ToList();
        localFiles = localFiles.Select(x => "/" + Path.GetFileName(x)).ToList();


        var client = FtpClientConfiguration.GetFtpClient();

        var listing = await client.GetNameListing();

        var ftpRemotePaths = listing.ToList();

        var result = ftpRemotePaths.Except(localFiles).ToList();
        if (result.Count == 0)
        {
            return;
        }

        await client.Connect();
        await client.DownloadFiles(localPath, result.ToArray(), FtpLocalExists.Skip);
        await client.Disconnect();
    }
}