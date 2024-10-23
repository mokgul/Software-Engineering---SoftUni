namespace ArtfulAdventures.Services.Common;

using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;

/// <summary>
/// Search engine for the application that searches the database for the given query and returns the results as a collection of search results.
/// </summary>
public class SearchEngine
{
    private readonly ArtfulAdventuresDbContext _data;

    public SearchEngine(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }

    /// <summary>
    /// Searches the database for the given query and returns the results as a collection of <see cref="Blog"/>s.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> A collection of <see cref="Blog"/>s.</returns>
    public async Task<ICollection<Blog>> SearchBlogs(string query)
    {
        var queryWords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());
        var dbBlogs = await _data.Blogs.Include(a => a.Author).ToListAsync();
        var blogs = dbBlogs.Where(b => queryWords.All(q =>
                b.Title.ToLower().Contains(q) || b.Content.ToLower().Contains(q) ||
                b.Author.UserName.ToLower().Contains(q)))
            .ToList();
        return blogs;
    }
    

    /// <summary>
    /// Searches the database for the given query and returns the results as a collection of <see cref="Picture"/>s.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> A collection of <see cref="Picture"/>s.</returns>
    public async Task<ICollection<Picture>> SearchPictures(string query)
    {
        var queryWords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());
        var dbPictures = await _data.Pictures.Include(u => u.Owner).ToListAsync();
        var pictures = dbPictures
            .Where(p => queryWords.All(q =>
                p.Description.ToLower().Contains(q) || p.Owner.UserName.ToLower().Contains(q)))
            .ToList();
        return pictures;
    }
    

    /// <summary>
    /// Searches the database for the given query and returns the results as a collection of <see cref="Challenge"/>s.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> A collection of <see cref="Challenge"/>s.</returns>
    public async Task<ICollection<Challenge>> SearchChallenges(string query)
    {
        var queryWords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());
        var dbChallenges = await _data.Challenges.ToListAsync();
        var challenges = dbChallenges.Where(c => queryWords.All(q =>
                c.Title.ToLower().Contains(q) || c.Requirements.ToLower().Contains(q) ||
                c.Creator.ToLower().Contains(q)))
            .ToList();

        return challenges;
    }
    

    /// <summary>
    /// Searches the database for the given query and returns the results as a collection of <see cref="ApplicationUser"/>s.
    /// </summary>
    /// <param name="query"></param>
    /// <returns> A collection of <see cref="ApplicationUser"/>s.</returns>
    public async Task<ICollection<ApplicationUser>> SearchUsers(string query)
    {
        var queryWords = query.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());
        var dbUsers = await _data.Users.Include(p => p.Portfolio).ToListAsync();
        var users = dbUsers.Where(u =>
                queryWords.All(
                    q => u.UserName.ToLower().Contains(q) || (u.Name != null && u.Name.ToLower().Contains(q))))
            .ToList();
        return users;
    }
}