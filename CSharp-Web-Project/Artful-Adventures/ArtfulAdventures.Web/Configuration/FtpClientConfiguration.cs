namespace ArtfulAdventures.Web.Configuration;

using FluentFTP.Client.BaseClient;
using FluentFTP;
using System.Net;

using static Common.GeneralApplicationConstants;

/// <summary>
///   This class is used to configure the FTP client.
/// </summary>
public static class FtpClientConfiguration
{
    /// <summary>
    ///  This method is used to configure the FTP client.
    /// </summary>
    /// <returns></returns>
    public static AsyncFtpClient GetFtpClient()
    {
        var client = new AsyncFtpClient();
        client.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
        client.Host = ftpServerUrl;
        client.Port = ftpPort;
        client.Config.TransferChunkSize = 8000000;
        client.Config.LocalFileBufferSize = 8000000;
        client.Config.EncryptionMode = FtpEncryptionMode.Explicit;
        client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);

        return client;
    }

    /// <summary>
    ///  This method is used to validate the FTP client certificate.
    /// </summary>
    /// <param name="control"></param>
    /// <param name="e"></param>
    private static void OnValidateCertificate(BaseFtpClient control, FtpSslValidationEventArgs e)
    {
        if (e.PolicyErrors != System.Net.Security.SslPolicyErrors.None)
        {
            // invalid cert, do you want to accept it?
            e.Accept = true;
        }
        else
        {
            e.Accept = true;
        }
    }
}