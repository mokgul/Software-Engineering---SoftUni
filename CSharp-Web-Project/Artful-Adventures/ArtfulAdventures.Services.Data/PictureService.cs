namespace ArtfulAdventures.Services.Data;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using Common;
using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;
using Interfaces;
using Web.ViewModels.Comment;
using Web.ViewModels.HashTag;
using Web.ViewModels.Picture;

/// <summary>
///   This service is responsible for picture related operations.
/// </summary>
public class PictureService : IPictureService
{
    private readonly ArtfulAdventuresDbContext _data;

    public PictureService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }

    /// <summary>
    ///  This method returns a PictureAddFormModel.
    /// </summary>
    /// <returns></returns>
    public async Task<PictureAddFormModel> GetPictureAddFormModelAsync()
    {
        var hashtags = await _data.HashTags.Select(h => new HashTagViewModel()
        {
            Id = h.Id,
            Name = h.Type
        }).ToListAsync();

        var model = new PictureAddFormModel()
        {
            HashTags = hashtags
        };
        return model;
    }

    /// <summary>
    ///  This method uploads a picture to the database.
    /// </summary>
    /// <param name="model"> Model containing the picture data. </param>
    /// <param name="userId"> The id of the user uploading the picture. </param>
    /// <param name="path"> The path of the picture. </param>
    public async Task UploadPictureAsync(PictureAddFormModel model, string userId, string path)
    {
        var selectedHashTags = GetSelectedHashtags(model);
        var user = await GetUser(userId);
        var picture = new Picture()
        {
            Url = path,
            UserId = user!.Id,
            Owner = user,
            CreatedOn = DateTime.UtcNow,
            Likes = 0,
            Description = model.Description,
        };
        picture.Portfolio.Add(new ApplicationUserPicture()
        {
            UserId = user.Id,
            User = user,
            PictureId = picture.Id,
            Picture = picture
        });

        var tagIds = selectedHashTags.Select(t => t.Id).ToList();
        var tags = await _data.HashTags.Where(h => tagIds.Contains(h.Id)).ToListAsync();
        foreach (var tag in selectedHashTags)
        {
            picture.PicturesHashTags.Add(new PictureHashTag()
            {
                Picture = picture,
                PictureId = picture.Id,
                Tag = tags.FirstOrDefault(t => t.Id == tag.Id)!,
                TagId = tag.Id
            });
        }

        await _data.Pictures.AddAsync(picture);
        await _data.SaveChangesAsync();
    }

    /// <summary>
    ///  This method returns a view model for a picture details page.
    /// </summary>
    /// <param name="id"> The id of the picture. </param>
    /// <param name="currentUser"> The id of the current user. </param>
    /// <returns> The <see cref="Task{PictureDetailsViewModel}"/>. </returns>
    /// <exception cref="NullReferenceException"> Thrown if the picture is not found. </exception>
    public async Task<PictureDetailsViewModel> GetPictureDetailsAsync(string id, string currentUser)
    {
        //Get picture with comments and hashtags
        var picture = await _data.Pictures
            .Include(p => p.PicturesHashTags)
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);

        if (picture == null)
        {
            throw new NullReferenceException("Picture not found!");
        }

        //Get picture owner with followers and following
        //Since the picture object has a foreign key relationship with the User table (through the UserId property), Entity Framework Core will automatically populate the Owner property of the picture
        var owner = await _data.Users
            .Include(p => p.Followers)
            .Include(p => p.Following)
            .Include(p => p.Portfolio)
            .FirstOrDefaultAsync(u => u.Id == picture.UserId);

        //Get picture hashtags
        var tagIds = picture.PicturesHashTags.Select(t => t.TagId).ToList();
        var tags = await _data.HashTags.Where(h => tagIds.Contains(h.Id)).ToListAsync();
        var hashtags = picture.PicturesHashTags.Select(h => new HashTagViewModel()
        {
            Id = h.TagId,
            Name = tags.FirstOrDefault(t => t.Id == h.TagId)!.Type,
        }).ToList();

        //Get picture comments
        var comments = _data.Comments.Where(c => c.PictureId.ToString() == id).Select(c => new CommentViewModel()
        {
            Id = c.Id,
            Content = c.Content,
            CreatedOn = c.CreatedOn,
            Author = c.Author,
        }).ToList();
        foreach (var comment in comments)
        {
            comment.AuthorPictureUrl =
                Path.GetFileName(_data.Users.FirstOrDefault(u => u.UserName == comment.Author)!.Url);
        }

        //Get current user
        var user = await _data.Users.FirstOrDefaultAsync(x => x.Id.ToString() == currentUser);
        var userMute = user!.MuteUntil != null && user!.MuteUntil > DateTime.UtcNow;

        //Create view model
        var model = new PictureDetailsViewModel()
        {
            Id = picture.Id.ToString(),
            Url = Path.GetFileName(picture.Url),
            Owner = picture.Owner.UserName,
            OwnerPictureUrl = Path.GetFileName(picture.Owner.Url),
            OwnerLevel = "Artist",
            OwnerPicturesCount = picture.Owner.Portfolio.Count,
            OwnerFollowersCount = picture.Owner.Followers.Count,
            OwnerFollowingCount = picture.Owner.Following.Count,
            Likes = picture.Likes,
            Description = picture.Description,
            HashTags = hashtags,
            CreatedOn = picture.CreatedOn,
            CommentsCount = comments.Count,
            Comments = comments,
            isCurrentUserMuted = userMute
        };

        return model;
    }

    /// <summary>
    ///  This method provides functionality for liking a picture.
    /// </summary>
    /// <param name="pictureId"> The id of the picture. </param>
    /// <returns> A boolean value indicating whether the picture was liked. </returns>
    public async Task<bool> LikePictureAsync(string pictureId)
    {
        var picture = _data.Pictures.FirstOrDefault(p => p.Id.ToString() == pictureId);
        if (picture == null)
        {
            return false;
        }

        picture.Likes++;
        await _data.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///  This methods provides functionality for addint pictures to a user's collection.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> AddToCollectionAsync(string id, string userId)
    {
        var user = await _data.Users
            .Include(p => p.Collection)
            .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
        if (user == null)
        {
            return "User not found!";
        }

        if (user!.Collection.Any(c => c.PictureId.ToString() == id))
        {
            return string.Empty;
        }

        user!.Collection.Add(new ApplicationUserCollection()
        {
            UserId = user.Id,
            User = user,
            PictureId = Guid.Parse(id),
            Picture = (await _data.Pictures.FirstOrDefaultAsync(p => p.Id.ToString() == id))!
        });
        await _data.SaveChangesAsync();
        return "You added this picture to your collection.";
    }

    /// <summary>
    ///  This method returns a view model with pictures from a user's portfolio for management.
    /// </summary>
    /// <param name="userId"> The id of the user. </param>
    /// <param name="page"> An integer representing the page number. </param>
    /// <returns> A collection of <see cref="PictureEditViewModel"/>. </returns>
    public async Task<ICollection<PictureEditViewModel>?> ManageGetAllPicturesAsync(string userId, int page = 1)
    {
        if (ValidatePage.Validate(page) == false)
        {
            return null;
        }

        const int pageSize = 9;
        var skip = (page - 1) * pageSize;

        var pictures = await _data.Pictures
            .Where(p => p.UserId.ToString() == userId)
            .Skip(skip)
            .Take(pageSize)
            .Select(p => new PictureEditViewModel()
            {
                Id = p.Id.ToString(),
                PictureUrl = Path.GetFileName(p.Url),
                Description = p.Description,
            })
            .ToListAsync();
        return pictures;
    }

    /// <summary>
    ///  This method provides a view model for editing a picture.
    /// </summary>
    /// <param name="id"> The id of the picture. </param>
    /// <returns> A <see cref="PictureEditViewModel"/>. </returns>
    public async Task<PictureEditViewModel?> GetPictureToEditAsync(string id)
    {
        var hashtags = await _data.HashTags.Select(h => new HashTagViewModel()
        {
            Id = h.Id,
            Name = h.Type
        }).ToListAsync();

        var picture = await _data.Pictures
            .Where(p => p.Id.ToString() == id)
            .Select(p => new PictureEditViewModel()
            {
                Id = p.Id.ToString(),
                Description = p.Description,
                HashTags = hashtags
            })
            .FirstOrDefaultAsync();

        return picture ?? null;
    }

    /// <summary>
    ///  This method provides functionality for editing a picture.
    /// </summary>
    /// <param name="model"> A <see cref="PictureEditViewModel"/>. </param>
    /// <returns> A boolean value indicating whether the picture was edited. </returns>
    public async Task<bool> EditPictureAsync(PictureEditViewModel model)
    {
        var picture = await _data.Pictures.FirstOrDefaultAsync(p => p.Id.ToString() == model.Id);
        if (picture == null)
        {
            return false;
        }

        picture!.Description = model.Description;
        var selectedHashTags = model.HashTags.Where(h => h.IsSelected).ToList();
        if (selectedHashTags.Count > 0)
        {
            var tagIds = selectedHashTags.Select(t => t.Id).ToList();
            var tags = await _data.HashTags.Where(h => tagIds.Contains(h.Id)).ToListAsync();
            picture.PicturesHashTags.Clear();
            foreach (var tag in selectedHashTags)
            {
                picture.PicturesHashTags.Add(new PictureHashTag()
                {
                    Picture = picture,
                    PictureId = picture.Id,
                    Tag = (tags.FirstOrDefault(t => t.Id == tag.Id))!,
                    TagId = tag.Id
                });
            }
        }

        await _data.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///  This method provides functionality for deleting a picture.
    /// </summary>
    /// <param name="id"> The id of the picture. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> A string representing the path to the picture in the ftp server (user for deleting the picture from the ftp server). </returns>
    /// <exception cref="ArgumentException"> Thrown if the picture is not found. </exception>
    public async Task<string> DeletePictureAsync(string id, string userId)
    {
        var picture = await _data.Pictures
            .Include(c => c.Comments)
            .Include(cl => cl.Collection)
            .Include(ph => ph.PicturesHashTags)
            .Include(p => p.Portfolio)
            .Include(o => o.Owner)
            .Where(u => u.Owner.Id.ToString() == userId)
            .FirstOrDefaultAsync(p => p.Id.ToString() == id);
        if (picture == null)
        {
            throw new ArgumentException("Picture not found.");
        }

        picture!.Comments.Clear();
        picture.Collection.Clear();
        picture.PicturesHashTags.Clear();
        picture.Portfolio.Clear();

        var path = picture.Url;

        _data.Pictures.Remove(picture);
        await _data.SaveChangesAsync();

        return path;
    }

    /// <summary>
    ///  This method returns a view model with pictures from a user's collection for management.
    /// </summary>
    /// <param name="userId"> The id of the user. </param>
    /// <param name="page"> An integer representing the page number. </param>
    /// <returns> A collection of <see cref="PictureEditViewModel"/>. </returns>
    public async Task<ICollection<PictureEditViewModel>?> ManageGetAllCollectionAsync(string userId, int page = 1)
    {
        if (ValidatePage.Validate(page) == false)
        {
            return null;
        }

        const int pageSize = 9;
        var skip = (page - 1) * pageSize;

        var model = await _data.Users
            .Where(u => u.Id.ToString() == userId)
            .Include(p => p.Collection)
            .Skip(skip)
            .Take(pageSize)
            .Select(c => c.Collection
                .Select(col => new PictureEditViewModel()
                {
                    Id = col.PictureId.ToString(),
                    PictureUrl = Path.GetFileName(col.Picture.Url),
                    Description = col.Picture.Description,
                })
                .ToList()
            )
            .FirstOrDefaultAsync();

        return model;
    }

    /// <summary>
    ///  This method provides functionality for removing a picture from a user's collection.
    /// </summary>
    /// <param name="id"> The id of the picture. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> A string representing a message. </returns>
    public async Task<string> RemoveFromCollectionAsync(string id, string userId)
    {
        var userCollection = await _data.Collection
            .Where(u => u.UserId.ToString() == userId && u.PictureId.ToString() == id)
            .FirstOrDefaultAsync();
        
        if (userCollection == null)
        {
            return string.Empty;
        }

        _data.Collection.Remove(userCollection);
        await _data.SaveChangesAsync();
        return "You removed this picture from your collection.";
    }


    private async Task<ApplicationUser?> GetUser(string userId)
    {
        return await _data.Users.Include(m => m.Portfolio).FirstOrDefaultAsync(u => u.Id.ToString() == userId);
    }

    private List<HashTagViewModel> GetSelectedHashtags(PictureAddFormModel model)
    {
        var seletedHashTags = model.HashTags.Where(h => h.IsSelected).ToList();
        return seletedHashTags;
    }
}