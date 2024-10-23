namespace ArtfulAdventures.Services.Common;

using Microsoft.EntityFrameworkCore;

using Data;

/// <summary>
/// Validates the sort parameter from the query string
/// </summary>
public class ValidateSortParameter
{
    private readonly ArtfulAdventuresDbContext _data;
    
    private readonly string[] _availableSorts = new []{"likes", "newest", "oldest"};
    
    public ValidateSortParameter(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }
    
    /// <summary>
    /// Validates the sort parameter from the query string 
    /// </summary>
    /// <param name="sort"></param>
    /// <returns> Returns true if the sort parameter is valid, otherwise false </returns>
    public async Task<bool> Validate(string sort)
    {
        if(string.IsNullOrEmpty(sort))
            return false;
        // Check if sort is one of the available sort options
        if (_availableSorts.Contains(sort))
            return true;

        // Check if sort is a valid tag
        var isTag = await _data.HashTags.AnyAsync(h => h.Type == sort.Replace(" ", "_"));
        if (isTag)
            return true;

        // Check if sort is a valid username
        var isUser = await _data.Users.AnyAsync(u => u.UserName == sort);
        if (isUser)
            return true;

        // Sort is not valid
        return false;
    }
}