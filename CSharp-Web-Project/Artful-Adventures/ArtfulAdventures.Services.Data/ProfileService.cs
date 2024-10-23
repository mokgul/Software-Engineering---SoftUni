namespace ArtfulAdventures.Services.Data;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;
using Interfaces;
using Web.ViewModels.Picture;
using Web.ViewModels.Skill;
using Web.ViewModels.UserProfile;

/// <summary>
///  This service is responsible for providing data for the user profile page.
/// </summary>
public class ProfileService : IProfileService
{
    private readonly ArtfulAdventuresDbContext _data;

    public ProfileService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }


    /// <summary>
    ///   Returns a ProfileViewModel for the given username.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <param name="userId"> A string for the userId (visiting user).</param>
    /// <returns> A ProfileViewModel.</returns>
    public async Task<ProfileViewModel?> GetProfileViewModelAsync(string username, string userId)
    {
        var user = await _data.Users
            .Include(m => m.Followers)
            .Include(s => s.Following)
            .Include(p => p.Portfolio)
            .ThenInclude(p => p.Picture)
            .Include(s => s.ApplicationUsersSkills)
            .ThenInclude(s => s.Skill)
            .FirstOrDefaultAsync(u => u.UserName == username);

        if (user == null)
        {
            return null;
        }

        ;

        var visitor = await _data.Users
            .Include(m => m.Followers)
            .Include(s => s.Following)
            .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

        var followed = false;
        if (user.Id != visitor!.Id)
        {
            followed = visitor.Following.Any(f => f.FollowedId == user.Id);
        }

        ICollection<SkillViewModel> skills = user!.ApplicationUsersSkills.Select(sa => new SkillViewModel()
        {
            Id = sa.SkillId,
            Name = sa.Skill.Type,
        }).ToList();

        var pictures = user!.Portfolio.Select(p => new PictureVisualizeViewModel()
        {
            Id = p.PictureId.ToString(),
            CreatedOn = p.Picture.CreatedOn,
            Likes = p.Picture.Likes,
            PictureUrl = Path.GetFileName(p.Picture!.Url),
        }).ToList();

        pictures = FilterBrokenUrls.FilterAsync(pictures);
        pictures = pictures.OrderByDescending(p => p.CreatedOn).ToList();

        var model = new ProfileViewModel()
        {
            Username = user.UserName,
            Email = user.Email,
            ProfilePictureUrl = Path.GetFileName(user.Url),
            Name = user.Name,
            Bio = user.Bio,
            About = user.About,
            CityName = user.CityName,
            Skills = skills,
            Pictures = pictures,
            isFollowed = followed,
            IsMuted = user.MuteUntil != null,
            MuteUntil = user.MuteUntil ?? DateTime.Now,
            FollowersCount = user.Followers.Count,
            FollowingCount = user.Following.Count,
            PicturesCount = user.Portfolio.Count,
        };
        return model;
    }


    /// <summary>
    ///  Provides functionality for following a user.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <param name="userId"> A string for the userId (visiting user).</param>
    /// <returns> A string with status message.</returns>
    public async Task<string> FollowAsync(string username, string userId)
    {
        var userVisited = await _data.Users.Include(m => m.Followers).Include(s => s.Following)
            .FirstOrDefaultAsync(u => u.UserName == username);

        var userVisitor = await _data.Users.Include(m => m.Followers).Include(s => s.Following)
            .FirstOrDefaultAsync(u => u.Id.ToString() == userId);

        if (userVisited!.Id == userVisitor!.Id)
        {
            return string.Empty;
        }

        var userFollow = new FollowerFollowing()
        {
            Follower = userVisitor,
            FollowerId = userVisitor!.Id,
            Followed = userVisited,
            FollowedId = userVisited!.Id,
        };

        // If the visited user is not followed by the visitor and the visitor is not following the visited user
        // The visited user does not have the visitor in their followers and the visitor does not have the visited user in their following
        if (userVisited!.Followers.All(f => f.FollowerId != userVisitor!.Id)
            && userVisitor!.Following.All(f => f.FollowedId != userVisited!.Id))
        {
            userVisited!.Followers.Add(userFollow);
            userVisitor!.Following.Add(userFollow!);
            await _data.SaveChangesAsync();
        }

        ;
        return "Success";
    }


    /// <summary>
    ///  Provides functionality for unfollowing a user.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <param name="userId"> A string for the userId (visiting user).</param>
    public async Task UnfollowAsync(string username, string userId)
    {
        var userVisited = await _data.Users.Include(m => m.Followers).Include(s => s.Following)
            .FirstOrDefaultAsync(u => u.UserName == username);

        var userVisitor = await _data.Users.Include(m => m.Followers).Include(s => s.Following)
            .FirstOrDefaultAsync(u => u.Id.ToString() == userId);


        if (userVisited!.Followers.Any(f => f.FollowerId == userVisitor!.Id)
            && userVisitor!.Following.Any(f => f.FollowedId == userVisited!.Id))
        {
            var userFollow = userVisited!.Followers.FirstOrDefault(f => f.FollowerId == userVisitor!.Id);
            userVisited!.Followers.Remove(userFollow!);
            userVisitor!.Following.Remove(userFollow!);
            await _data.SaveChangesAsync();
        }
    }


    /// <summary>
    ///  Provides a functionality for displaying a user's portfolio.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A PortfolioViewModel.</returns>
    /// <exception cref="NullReferenceException"> Thrown when the user is not found.</exception>
    public async Task<PortfolioViewModel?> GetPortfolioAsync(string username)
    {
        var user = await _data.Users
            .Where(u => u.UserName == username)
            .Select(u => new
            {
                Pictures = u.Portfolio.Select(p => new PictureVisualizeViewModel
                {
                    Id = p.PictureId.ToString(),
                    CreatedOn = p.Picture.CreatedOn,
                    Likes = p.Picture.Likes,
                    PictureUrl = Path.GetFileName(p.Picture.Url)
                })
            })
            .FirstOrDefaultAsync();

        if (user == null)
        {
            throw new NullReferenceException("User not found.");
        }

        if (!user.Pictures.Any())
        {
            return null;
        }

        var pictures = user.Pictures.ToList();
        pictures = FilterBrokenUrls.FilterAsync(pictures);
        pictures = pictures.OrderByDescending(p => p.CreatedOn).ToList();

        var model = new PortfolioViewModel
        {
            Pictures = pictures
        };

        return model;
    }

    /// <summary>
    ///  Provides a functionality for displaying a user's collection.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A PortfolioViewModel.</returns>
    /// <exception cref="NullReferenceException"> Thrown when the user is not found.</exception>
    public async Task<PortfolioViewModel?> GetCollectionAsync(string username)
    {
        var user = await _data.Users
            .Where(u => u.UserName == username)
            .Select(u => new
            {
                Pictures = u.Collection.Select(p => new PictureVisualizeViewModel
                {
                    Id = p.PictureId.ToString(),
                    CreatedOn = p.Picture.CreatedOn,
                    Likes = p.Picture.Likes,
                    PictureUrl = Path.GetFileName(p.Picture.Url)
                })
            })
            .FirstOrDefaultAsync();

        if (user == null)
        {
            throw new NullReferenceException("User not found.");
        }

        if (!user.Pictures.Any())
        {
            return null;
        }

        var pictures = user.Pictures.ToList();
        pictures = FilterBrokenUrls.FilterAsync(pictures);
        pictures = pictures.OrderByDescending(p => p.CreatedOn).ToList();

        var model = new PortfolioViewModel
        {
            Pictures = pictures
        };

        return model;
    }

    
    /// <summary>
    ///  Provides a functionality for displaying a user's followers.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns></returns>
    /// <exception cref="NullReferenceException"> Thrown when the user is not found.</exception>
    public async Task<FollowViewModel?> GetFollowersAsync(string username)
    {
        var user = await _data.Users.Include(m => m.Followers).Include(m => m.Following)
            .FirstOrDefaultAsync(u => u.UserName == username);

        if (user == null)
        {
            throw new NullReferenceException("User not found.");
        }

        if (user!.Followers.Count == 0)
        {
            return null;
        }

        var followers = user!.Followers.Select(f => new ProfilePartialView()
        {
            Username = _data.Users.FirstOrDefault(u => u.Id == f.FollowerId)!.UserName!,
            ProfilePictureUrl = Path.GetFileName(f.Follower!.Url),
            Name = f.Follower.Name,
            Bio = f.Follower.Bio,
            CityName = f.Follower.CityName,
            FollowersCount = _data.Users.Include(p => p.Followers).FirstOrDefault(u => u.Id == f.FollowerId)!.Followers
                .Count,
            FollowingCount = _data.Users.Include(p => p.Following).FirstOrDefault(u => u.Id == f.FollowerId)!.Following
                .Count,
            PicturesCount = _data.Users.Include(p => p.Portfolio).FirstOrDefault(u => u.Id == f.FollowerId)!.Portfolio
                .Count,
        }).ToList();

        var model = new FollowViewModel()
        {
            Followers = followers,
        };
        return model;
    }

    
    /// <summary>
    ///  Provides a functionality for displaying a user's following.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A FollowViewModel.</returns>
    /// <exception cref="NullReferenceException"> Thrown when the user is not found.</exception>
    public async Task<FollowViewModel?> GetFollowingAsync(string username)
    {
        var user = await _data.Users.Include(m => m.Followers).Include(m => m.Following)
            .FirstOrDefaultAsync(u => u.UserName == username);

        if (user == null)
        {
            throw new NullReferenceException("User not found.");
        }

        if (user!.Following.Count == 0)
        {
            return null;
        }

        var following = user!.Following.Select(f => new ProfilePartialView()
        {
            Username = _data.Users.FirstOrDefault(u => u.Id == f.FollowedId)?.UserName!,
            ProfilePictureUrl = Path.GetFileName(f.Followed!.Url),
            Name = f.Followed.Name,
            Bio = f.Followed.Bio,
            CityName = f.Followed.CityName,
            FollowersCount = _data.Users.Include(p => p.Followers).FirstOrDefault(u => u.Id == f.FollowedId)!.Followers
                .Count,
            FollowingCount = _data.Users.Include(p => p.Following).FirstOrDefault(u => u.Id == f.FollowedId)!.Following
                .Count,
            PicturesCount = _data.Users.Include(p => p.Portfolio).FirstOrDefault(u => u.Id == f.FollowedId)!.Portfolio
                .Count,
        }).ToList();

        var model = new FollowViewModel()
        {
            Followers = following,
        };
        return model;
    }
}