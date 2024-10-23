namespace ArtfulAdventures.Services.Data.Interfaces;

using Web.ViewModels;
using Web.ViewModels.Picture;

/// <summary>
///  Defines the <see cref="IExploreService" />.
/// </summary>
public interface IExploreService
{
    /// <summary>
    ///  Provides a view model for the Explore page.
    /// </summary>
    /// <param name="sort"> A string representing the sort order. </param>
    /// <param name="page"> An integer representing the page number. </param>
    /// <returns> A view model for the Explore page. </returns>
    Task<ExploreViewModel> GetExploreViewModelAsync(string sort, int page);
    
    /// <summary>
    ///  Provides a view model for the Home page.
    /// </summary>
    /// <returns></returns>
    Task<ICollection<PictureVisualizeViewModel>> GetPicturesForHomePageAsync();

}

