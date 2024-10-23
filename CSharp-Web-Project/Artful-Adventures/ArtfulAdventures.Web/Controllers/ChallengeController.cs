namespace ArtfulAdventures.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using System.Security.Claims;
using ArtfulAdventures.Services.Common;
using ArtfulAdventures.Services.Data.Interfaces;
using Configuration;
using static Common.GeneralApplicationConstants;

[Authorize]
public class ChallengeController : Controller
{
    private readonly IChallengeService _challengeService;

    public ChallengeController(IChallengeService service)
    {
        _challengeService = service;
    }

    /// <summary>
    ///  Provides a method for getting all challenges.
    /// </summary>
    /// <param name="page"> Аn int for the page number. </param>
    /// <returns> The <see cref="Task{ChallengeAddFormModel}"/>. </returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(int page)
    {
        var model = await _challengeService.GetAllAsync(page);
        ViewBag.CurrentPage = page;

        if (model != null)
            return View(model);

        TempData["Error"] = "Invalid page number.";
        return RedirectToAction("GetAll", "Challenge", new { page = 1 });
    }

    /// <summary>
    ///  Provides a method for getting the challenge details.
    /// </summary>
    /// <param name="id"> The id of the challenge. </param>
    /// <returns> The <see cref="Task{ChallengeAddFormModel}"/>. </returns>
    public async Task<IActionResult> ChallengeDetails(int id)
    {
        var model = await _challengeService.GetChallengeDetailsAsync(id);
        if (model != null)
            return View(model);
        TempData["ErrorNotFound"] = "Challenge not found.";
        return RedirectToAction("GetAll", "Challenge", new { page = 1 });
    }

    
    /// <summary>
    ///  Provides a method for participating in a challenge.
    /// </summary>
    /// <param name="id"> The id of the challenge. </param>
    /// <returns> The <see cref="Task{ChallengeAddFormModel}"/>. </returns>
    [HttpPost]
    public async Task<IActionResult> Participate(int id)
    {
        var userId = GetUserId();
        var path = await UploadFile();
        if (string.IsNullOrEmpty(path))
        {
            TempData["ErrorNotFound"] = "Please select a file to upload.";
            return RedirectToAction("GetAll", "Challenge", new { page = 1 });
        }

        var result = await _challengeService.ParticipateAsync(id, userId, path);
        if (result == false)
        {
            TempData["ErrorNotFound"] = "You have already participated in this challenge.";
            return RedirectToAction("ChallengeDetails", new { id = id });
        }

        TempData["Success"] = "Your picture was uploaded successfully!";
        return RedirectToAction("ChallengeDetails", new { id = id });
    }

    
    /// <summary>
    ///  Provides a method for uploading a file.
    /// </summary>
    /// <returns></returns>
    private async Task<string> UploadFile()
    {
        //Reads the form data from the request body.
        var form = await Request.ReadFormAsync();
        if (form.Files.Count == 0)
        {
            return string.Empty;
        }

        //Gets the first file and saves it to the specified path.
        var file = form.Files.First();
        var imageValidator = new ValidateFileIsImage();
        if (imageValidator.Validate(file) == false)
            return string.Empty;
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", fileName);

        //Resize the image
        Bitmap newImage = SaveFileLocal.ResizeImage(file);
        SaveFileLocal.SaveAsync(filePath, newImage);

        //Get the URL of the file to be uploaded
        var url = Path.Combine(ftpServerUrl, fileName);

        //Upload the file to the FTP server
        await UploadToFtpServer.UploadFile(fileName, filePath);

        return url;
    }

    
    /// <summary>
    ///  Gets the user id.
    /// </summary>
    /// <returns> The <see cref="string"/>. </returns>
    private string GetUserId()
    {
        return this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
    }
}