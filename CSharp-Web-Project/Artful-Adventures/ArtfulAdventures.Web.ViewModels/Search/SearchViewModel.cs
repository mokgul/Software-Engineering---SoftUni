namespace ArtfulAdventures.Web.ViewModels.Search;

/// <summary>
///  This class is used to display the search results for all entities (pictures, challenges, blogs, users).
/// </summary>
public class SearchViewModel
{
    public ICollection<PictureSearchViewModel>? Pictures { get; set; }

    public ICollection<ChallengeSearchViewModel>? Challenges { get; set; } 

    public ICollection<BlogSearchViewModel>? Blogs { get; set; }

    public ICollection<UserSearchViewModel>? Users { get; set; }

    public int ResultsCount { get; set; } 
    public int SearchTime { get; set; }
}

