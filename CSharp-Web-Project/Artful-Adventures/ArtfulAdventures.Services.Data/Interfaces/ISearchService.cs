namespace ArtfulAdventures.Services.Data.Interfaces;

using Web.ViewModels.Search;


/// <summary>
///  Defines the search service.
/// </summary>
public interface ISearchService
{
    /// <summary>
    ///  The search service is responsible for searching the database for entries matching the query.
    /// </summary>
    /// <param name="query"> The query is the search term. </param>
    /// <param name="page"> The page is the page number of the search results. </param>
    /// <returns> The search view model is the model that is returned to the search results page. </returns>
    Task<SearchViewModel> SearchAsync(string query, int page);
}