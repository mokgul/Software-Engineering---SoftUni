namespace ArtfulAdventures.Services.Data.Interfaces;

using Web.ViewModels.Picture;

/// <summary>
/// Defines the <see cref="IPictureService" />.
/// </summary>
public interface IPictureService
{
    /// <summary>
    ///  Provides a PictureAddFormModel for the PictureController.
    /// </summary>
    /// <returns> The <see cref="Task{PictureAddFormModel}"/>. </returns>
    Task<PictureAddFormModel> GetPictureAddFormModelAsync();

    /// <summary>
    ///  Provides a method for uploading a picture.
    /// </summary>
    /// <param name="model"> The model <see cref="PictureAddFormModel"/>. </param>
    /// <param name="userId"> The userId <see cref="string"/> . </param>
    /// <param name="path"> The path of the picture for the database <see cref="string"/> . </param>
    /// <returns> The <see cref="Task"/>. </returns>
    Task UploadPictureAsync(PictureAddFormModel model, string userId, string path);

    /// <summary>
    ///  Provides a method for getting picture details.
    /// </summary>
    /// <param name="id"> The id of the picture <see cref="string"/>. </param>
    /// <param name="currentUser"> The currentUser (username) <see cref="string"/>. </param>
    /// <returns> The <see cref="Task{PictureDetailsViewModel}"/>. </returns>
    Task <PictureDetailsViewModel> GetPictureDetailsAsync(string id, string currentUser);

    /// <summary>
    /// Provides a method for liking a picture.
    /// </summary>
    /// <param name="pictureId"> The id of the picture <see cref="string"/>. </param>
    /// <returns> The <see cref="Task"/>. </returns>
    Task<bool> LikePictureAsync(string pictureId);
    
    /// <summary>
    ///  Provides a method for adding a picture to the user's collection (Favorite).
    /// </summary>
    /// <param name="id"> The id of the picture <see cref="string"/>. </param>
    /// <param name="userId"> The userId <see cref="string"/>. </param>
    /// <returns> A string for status message </returns>
    Task<string> AddToCollectionAsync(string id, string userId);

    /// <summary>
    /// Provides a method for getting all pictures from the Portfolio of the current user for managing.
    /// </summary>
    /// <param name="userId"> The userId <see cref="string"/>. </param>
    /// <param name="page"> An integer for the current page <see cref="int"/>. </param>
    /// <returns>A collection of <see cref="PictureEditViewModel"/> </returns>
    Task<ICollection<PictureEditViewModel>?> ManageGetAllPicturesAsync(string userId, int page);
    
    /// <summary>
    /// Provides a method for getting a picture for editing or deleting.
    /// </summary>
    /// <param name="id"> The id of the picture <see cref="string"/>. </param>
    /// <returns> The <see cref="Task{PictureEditViewModel}"/>. </returns>
    Task<PictureEditViewModel?> GetPictureToEditAsync(string id);

    /// <summary>
    ///  Provides a method for editing a picture.
    /// </summary>
    /// <param name="model"> The model <see cref="PictureEditViewModel"/>. </param>
    /// <returns> The <see cref="Task"/>. </returns>
    Task<bool> EditPictureAsync(PictureEditViewModel model);

    /// <summary>
    ///  Provides a method for deleting a picture.
    /// </summary>
    /// <param name="id"> The id of the picture <see cref="string"/>. </param>
    /// <param name="userId"> The userId <see cref="string"/>. </param>
    /// <returns> A string for status message </returns>
    Task<string> DeletePictureAsync(string id, string userId);

    /// <summary>
    /// Provides a method for getting all pictures from the Collection of the current user for managing.
    /// </summary>
    /// <param name="userId"> The userId <see cref="string"/>. </param>
    /// <param name="page"> An integer for the current page <see cref="int"/>. </param>
    /// <returns> A collection of <see cref="PictureEditViewModel"/> </returns>
    Task<ICollection<PictureEditViewModel>?> ManageGetAllCollectionAsync(string userId, int page);
    
    /// <summary>
    /// Provides a method for removing a picture from the user's collection (Favorite).
    /// </summary>
    /// <param name="id"> The id of the picture <see cref="string"/>. </param>
    /// <param name="userId"> The userId <see cref="string"/>. </param>
    /// <returns> A string for status message </returns>
    Task<string> RemoveFromCollectionAsync(string id, string userId);


}

