namespace ArtfulAdventures.Services.Data.Interfaces;

using Web.ViewModels;

/// <summary>
///  Defines the <see cref="IFollowingService" />.
/// </summary>
public interface IFollowingService
{
    /// <summary>
    ///  Provides a view model for the Following page.
    /// </summary>
    /// <param name="sort"> A string representing the sort order. </param>
    /// <param name="page"> An integer representing the page number. </param>
    /// <param name="username"> A string representing the username of the current user. </param>
    /// <returns> A view model for the Following page. </returns>
    Task<ExploreViewModel> GetExploreViewModelAsync(string sort, int page, string username);
}

