namespace ArtfulAdventures.Services.Data;

using System.Diagnostics;

using ArtfulAdventures.Data;
using Common;
using Interfaces;
using Web.ViewModels.Search;


/// <summary>
///  The search service is responsible for searching the database for entries matching the query.
/// </summary>
public class SearchService : ISearchService
{
    private readonly ArtfulAdventuresDbContext _data;
    
    public SearchService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }
    
    /// <summary>
    ///  The search service is responsible for searching the database for entries matching the query.
    /// </summary>
    /// <param name="query"> The query is the search term. </param> 
    /// <param name="page"> The page is the page number of the search results. </param>
    /// <returns> The search view model is the model that is returned to the search results page. </returns>
    public async Task<SearchViewModel> SearchAsync(string query, int page)
    {
        const int pageSize = 10;
        var skip = (page - 1) * pageSize;
        
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        
        var search = new SearchEngine(_data);
        
        var pictures = await search.SearchPictures(query);
        var blogs = await search.SearchBlogs(query);
        var users = await search.SearchUsers(query);
        var challenges = await search.SearchChallenges(query);
        
        var picturesModel = pictures.Select(p => new PictureSearchViewModel
        {
            Id = p.Id.ToString(),
            Description = p.Description,
            PictureUrl = Path.GetFileName(p.Url),
            Owner = p.Owner.UserName,
            CreatedOn = p.CreatedOn,
        }).ToList();
        
        var blogsModel = blogs.Select(b => new BlogSearchViewModel
        {
            Id = b.Id.ToString(),
            Title = b.Title,
            Content = b.Content,
            Author = b.Author.UserName,
            CreatedOn = b.CreatedOn,
        }).ToList();
        
        var usersModel = users.Select(u => new UserSearchViewModel
        {
            Id = u.Id.ToString(),
            UserName = u.UserName,
            Name = u.Name,
            Uploads = u.Portfolio.Count,
        }).ToList();
        
        var challengesModel = challenges.Select(c => new ChallengeSearchViewModel
        {
            Id = c.Id,
            Creator = c.Creator,
            CreatedOn = c.CreatedOn,
            Requirements = c.Requirements,
        }).ToList();
        
        picturesModel = picturesModel.Skip(skip).Take(pageSize).ToList();
        blogsModel = blogsModel.Skip(skip).Take(pageSize).ToList();
        usersModel = usersModel.Skip(skip).Take(pageSize).ToList();
        challengesModel = challengesModel.Skip(skip).Take(pageSize).ToList();
        
        var model = new SearchViewModel
        {
            Pictures = picturesModel,
            Blogs = blogsModel,
            Users = usersModel,
            Challenges = challengesModel,
            ResultsCount = pictures.Count + blogs.Count + users.Count + challenges.Count,
        };

        stopwatch.Stop();
        model.SearchTime = (int)stopwatch.Elapsed.TotalMilliseconds;
        
        return model;
    }
}