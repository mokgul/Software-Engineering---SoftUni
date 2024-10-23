using ArtfulAdventures.Services.Common;
using Microsoft.AspNetCore.Authorization;

namespace ArtfulAdventures.Web.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Security.Claims;
    using ArtfulAdventures.Services.Data.Interfaces;
    using ArtfulAdventures.Web.Configuration;
    using ArtfulAdventures.Web.ViewModels.Picture;
    using Microsoft.AspNetCore.Mvc;
    using static ArtfulAdventures.Common.GeneralApplicationConstants;

    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class PictureController : Controller
    {
        private readonly IPictureService _pictureService;

        public PictureController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }


        /// <summary>
        ///  Provides a view model for uploading a picture.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Upload()
        {
            var model = await _pictureService.GetPictureAddFormModelAsync();

            return View(model);
        }


        /// <summary>
        ///  Provides a method for uploading a picture.
        /// </summary>
        /// <param name="model"> The model <see cref="PictureAddFormModel"/>. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpPost]
        public async Task<IActionResult> Upload(PictureAddFormModel model)
        {
            var userId = GetUserId();
            try
            {
                var path = await UploadFile();
                if (string.IsNullOrEmpty(path))
                {
                    ModelState.AddModelError("path", "Please select a file (only images are supported) to upload.");
                }

                if (!ModelState.IsValid)
                {
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",
                        Path.GetFileName(path)));
                    return View(model);
                }

                await _pictureService.UploadPictureAsync(model, userId, path);
            }
            catch (Exception)
            {
                return View(model);
            }

            TempData["Success"] = "Your picture was uploaded successfully!";
            return RedirectToAction("Upload", "Picture");
        }


        /// <summary>
        ///  Provides a method for displaying picture details.
        /// </summary>
        /// <param name="id"> The picture id. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpGet]
        public async Task<IActionResult> PictureDetails(string id)
        {
            try
            {
                var currentUser = GetUserId();
                var picture = await _pictureService.GetPictureDetailsAsync(id, currentUser);

                return View(picture);
            }
            catch (NullReferenceException ex)
            {
                TempData["NotFound"] = ex.Message;
                return RedirectToAction("All", "Explore", new { sort = "", page = 1 });
            }
        }

        /// <summary>
        ///  Provides a method for liking a picture.
        /// </summary>
        /// <param name="pictureId"> The picture id. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpPost]
        public async Task<IActionResult> LikePicture(string pictureId)
        {
            var result = await _pictureService.LikePictureAsync(pictureId);

            if (result)
                return RedirectToAction("PictureDetails", new { id = pictureId });

            TempData["Message"] = "Something went wrong. Please try again later.";
            return RedirectToAction("PictureDetails", new { id = pictureId });
        }

        /// <summary>
        ///  Provides a method for adding a picture to a collection.
        /// </summary>
        /// <param name="pictureId"> The picture id. </param>
        [HttpPost]
        public async Task<IActionResult> AddToCollection(string pictureId)
        {
            var userId = GetUserId();
            var result = await _pictureService.AddToCollectionAsync(pictureId, userId);
            if (string.IsNullOrEmpty(result))
            {
                TempData["Message"] = "You already have this picture in your collection.";
                return RedirectToAction("PictureDetails", new { id = pictureId });
            }
            else if (result == "User not found!")
            {
                TempData["Message"] = "User not found!";
                return RedirectToAction("PictureDetails", new { id = pictureId });
            }

            TempData["Success"] = result;
            return RedirectToAction("PictureDetails", new { id = pictureId });
        }


        /// <summary>
        ///  Provides a method for displaying all pictures of a user's portfolio for managing purposes.
        /// </summary>
        /// <param name="page"> An integer for the current page. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpGet]
        public async Task<IActionResult> ManageGetAllPictures(int page)
        {
            ViewBag.CurrentPage = page;
            ViewBag.Action = "ManageGetAllPictures";
            var userId = GetUserId();
            var model = await _pictureService.ManageGetAllPicturesAsync(userId, page);

            if (model != null)
                return View(model);

            TempData["Error"] = "Page not found.";
            return RedirectToAction("ManageGetAllPictures", "Picture", new { page = 1 });
        }


        /// <summary>
        ///  Provides a a view model for editing a picture.
        /// </summary>
        /// <param name="id"> The picture id. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpGet]
        public async Task<IActionResult> EditPicture(string id)
        {
            var model = await _pictureService.GetPictureToEditAsync(id);
            if (model != null)
                return View(model);

            TempData["Error"] = "Picture not found.";
            return RedirectToAction("ManageGetAllPictures", "Picture", new { page = 1 });
        }


        /// <summary>
        ///  Provides a method for editing a picture.
        /// </summary>
        /// <param name="model"> The model <see cref="PictureEditViewModel"/>. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpPost]
        public async Task<IActionResult> EditPicture(PictureEditViewModel model)
        {
            var result = await _pictureService.EditPictureAsync(model);

            if (!result)
            {
                TempData["Error"] = "Picture not found.";
                return RedirectToAction("ManageGetAllPictures", "Picture", new { page = 1 });
            }

            TempData["Success"] = "Your picture was edited successfully!";
            return RedirectToAction("ManageGetAllPictures", "Picture", new { page = 1 });
        }


        /// <summary>
        ///  Provides a method for deleting a picture.
        /// </summary>
        /// <param name="id"> The picture id. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpPost]
        public async Task<IActionResult> DeletePicture(string id)
        {
            var userId = GetUserId();
            try
            {
                var pathToDelete = await _pictureService.DeletePictureAsync(id, userId);
                await DeleteFromFtpServer.DeleteFile(pathToDelete);
            }
            catch (ArgumentException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("ManageGetAllPictures", "Picture", new { page = 1 });
            }

            TempData["Success"] = "Your picture was deleted successfully!";
            return RedirectToAction("ManageGetAllPictures", "Picture", new { page = 1 });
        }

        /// <summary>
        ///  Provides a method for displaying all pictures of a user's collection for managing purposes.
        /// </summary>
        /// <param name="page"> An integer for the current page. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpGet]
        public async Task<IActionResult> ManageGetAllCollection(int page)
        {
            ViewBag.CurrentPage = page;
            ViewBag.Action = "ManageGetAllCollection";
            var userId = GetUserId();
            var model = await _pictureService.ManageGetAllCollectionAsync(userId, page);

            if (model != null)
                return View("ManageGetAllPictures", model);

            TempData["Error"] = "Page not found.";
            return RedirectToAction("ManageGetAllCollection", "Picture", new { page = 1 });
        }


        /// <summary>
        ///  Provides a method for removing a picture from a collection.
        /// </summary>
        /// <param name="id"> The picture id. </param>
        /// <returns> The <see cref="Task{IActionResult}"/>. </returns>
        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(string id)
        {
            var userId = GetUserId();

            var result = await _pictureService.RemoveFromCollectionAsync(id, userId);

            if (string.IsNullOrEmpty(result))
            {
                TempData["Error"] = "Picture not found.";
                return RedirectToAction("ManageGetAllCollection", "Picture", new { page = 1 });
            }

            TempData["Success"] = result;
            return RedirectToAction("ManageGetAllCollection", "Picture", new { page = 1 });
        }

        
        /// <summary>
        ///  Provides a method for getting the user id.
        /// </summary>
        /// <returns> The <see cref="string"/>. </returns>
        private string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }

        
        /// <summary>
        ///  Provides a method for uploading a file to the FTP server.
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
    }
}