namespace ArtfulAdventures.Services.Data;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ArtfulAdventures.Data;
using Common;
using Interfaces;
using Web.ViewModels;
using Web.ViewModels.HashTag;
using Web.ViewModels.Picture;

/// <summary>
///  Provides functionality for the Explore page.
/// </summary>
public class ExploreService : IExploreService
{
    private readonly ArtfulAdventuresDbContext _data;

    public ExploreService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }
    
    /// <summary>
    ///  Provides a view model for the Explore page.
    /// </summary>
    /// <param name="sort"> A string representing the sort order. </param>
    /// <param name="page"> An integer representing the page number. </param>
    /// <returns> A view model for the Explore page. </returns>
    /// <exception cref="ArgumentException"></exception>
    public async Task<ExploreViewModel> GetExploreViewModelAsync(string sort, int page = 1)
    {
        if(ValidatePage.Validate(page) == false)
        {
            throw new ArgumentException("Invalid page number!");
        }
        
        const int pageSize = 20;
        var skip = (page - 1) * pageSize;
        var hashtags = await _data.HashTags
            .Include(h => h.PicturesHashTags)
            .OrderByDescending(h => h.PicturesHashTags.Count)
            .Select(h => new HashTagViewModel()
            {
                Id = h.Id,
                Name = h.Type.Replace("_", " "),
                PicturesCount = h.PicturesHashTags.Count
            })
            .Take(14)
            .ToListAsync();
        var dropDownMenuTags = await _data.HashTags
            .Select(h => new HashTagViewModel()
        {
            Id = h.Id,
            Name = h.Type.Replace("_", " ")
        })
            .ToListAsync();

        var pictures = await _data.Pictures
            .Include(t => t.PicturesHashTags)
            .OrderByDescending(p => p.CreatedOn)
            .Skip(skip)
            .Take(pageSize)
            .Select(p => new PictureVisualizeViewModel()
            {
                Id = p.Id.ToString(),
                Owner = p.Owner.UserName,
                PictureUrl = Path.GetFileName(p.Url),
                CreatedOn = p.CreatedOn,
                Likes = p.Likes,
                HashTags = p.PicturesHashTags.Select(h => h.Tag.Type).ToList()
            })
            .ToListAsync();


        pictures = FilterBrokenUrls.FilterAsync(pictures);

        pictures = await SortPicturesAsync(sort, pictures);

        var model = new ExploreViewModel()
        {
            HashTags = hashtags,
            TagsForDropDown = dropDownMenuTags,
            Pictures = pictures
        };
        return model;
    }
    

    /// <summary>
    ///  Provides a view model for the Home page.
    /// </summary>
    /// <returns></returns>
    public async Task<ICollection<PictureVisualizeViewModel>> GetPicturesForHomePageAsync()
    {
        var model = await _data.Pictures.Select(p => new PictureVisualizeViewModel()
        {
            Id = p.Id.ToString(),
            PictureUrl = Path.GetFileName(p.Url),
        }).Take(20).ToListAsync();
        model = FilterBrokenUrls.FilterAsync(model);
        return model;
    }
    
    
    /// <summary>
    ///  Sorts the pictures by the given parameter.
    /// </summary>
    /// <param name="sort"> A string representing the sort order. </param>
    /// <param name="pictures"> A list of PictureVisualizeViewModel. </param>
    /// <returns> A list of PictureVisualizeViewModel. </returns>
    /// <exception cref="ArgumentException"> Thrown if the sort parameter is invalid. </exception>
    private async Task<List<PictureVisualizeViewModel>> SortPicturesAsync(string sort,
        List<PictureVisualizeViewModel> pictures)
    {
        if (string.IsNullOrWhiteSpace(sort))
        {
            return pictures;
        }
        var sortValidator = new ValidateSortParameter(_data);
        bool isValid = await sortValidator.Validate(sort);
        if (!isValid)
        {
            throw new ArgumentException("Invalid sort parameter!");
        }

        var owner = string.Empty;
        var tag = string.Empty;
        if (sort != "likes" && sort != "newest" && sort != "oldest")
        {
            if (!_data.HashTags.Any(h => h.Type == sort.Replace(" ", "_")))
            {
                owner = sort;
                sort = "author";
            }
            else
            {
                tag = sort.Replace(" ", "_");
                sort = "tag";
            }
        }

        if (sort != "likes" && sort != "newest" && sort != "oldest" && sort != "tag")
        {
            if (!_data.Users.Any(u => u.UserName == owner))
                throw new ArgumentException($"User {owner} does not exist.");
        }

        switch (sort)
        {
            case "likes":
                pictures = pictures.OrderByDescending(p => p.Likes).ToList();
                break;
            case "newest":
                pictures = pictures.OrderByDescending(p => p.CreatedOn).ToList();
                break;
            case "oldest":
                pictures = pictures.OrderBy(p => p.CreatedOn).ToList();
                break;
            case "author":
                pictures = pictures.Where(p => p.Owner == owner).ToList();
                break;
            case "tag":
                tag = tag.Replace(" ", "_");
                pictures = pictures.Where(p => p.HashTags.Contains(tag)).ToList();
                break;
            default:
                break;
        }

        return pictures;
    }
}