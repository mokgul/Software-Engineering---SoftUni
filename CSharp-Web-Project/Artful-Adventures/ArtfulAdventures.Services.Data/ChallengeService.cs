namespace ArtfulAdventures.Services.Data;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;
using Common;
using Interfaces;
using Web.ViewModels.Challenges;
using static ArtfulAdventures.Common.GeneralApplicationConstants;

public class ChallengeService : IChallengeService
{
    private readonly ArtfulAdventuresDbContext _data;

    public ChallengeService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }

    /// <summary>
    ///  Provides a method for getting all challenges.
    /// </summary>
    /// <param name="page"> Аn int for the page number. </param>
    /// <returns> The <see cref="Task{ChallengeAddFormModel}"/>. </returns>
    public async Task<ChallengesViewModel?> GetAllAsync(int page = 1)
    {
        if (!ValidatePage.Validate(page))
        {
            return null;
        }

        const int pageSize = 6;
        var skip = (page - 1) * pageSize;
        var challenges = await _data.Challenges
            .Select(c => new ChallengeVisualizeViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Creator = c.Creator,
                CreatedOn = c.CreatedOn,
                Participants = c.Participants,
                PictureUrl = Path.GetFileName(c.Url),
            })
            .OrderByDescending(x => x.CreatedOn)
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();

        var model = new ChallengesViewModel()
        {
            Challenges = challenges
        };
        return model;
    }

    /// <summary>
    ///  Provides a method for getting the challenge details view model.
    /// </summary>
    /// <param name="id"> The id of the challenge. </param>
    /// <returns> The <see cref="Task{ChallengeAddFormModel}"/>. </returns>
    public async Task<ChallengeDetailsViewModel?> GetChallengeDetailsAsync(int id)
    {
        var challenge = await _data.Challenges.Where(x => x.Id == id)
            .Select(c => new ChallengeDetailsViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Requirements = c.Requirements,
                Url = Path.GetFileName(c.Url),
                CreatedOn = c.CreatedOn,
                Creator = c.Creator,
                Participants = c.Participants,
            })
            .FirstOrDefaultAsync();
        if (challenge == null)
        {
            return null;
        }

        var pictures = await _data.Pictures
            .Where(x => x.ChallengeId == id)
            .ToDictionaryAsync(x => x.Id.ToString(), x => Path.GetFileName(x.Url));
        if(pictures.Any())
            challenge.Pictures = pictures;
        
        return challenge;
    }
    
    /// <summary>
    ///  Provides a method for participating in a challenge.
    /// </summary>
    /// <param name="id"> The id of the challenge. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <param name="path"> The path to the image. </param>
    /// <returns> The bool for the result. </returns>
    public async Task<bool> ParticipateAsync(int id, string userId, string path)
    {
        var challenge = await _data.Challenges.FindAsync(id);
        if (challenge == null)
        {
            return false;
        }

        var user = await _data.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);
        if (user == null)
        {
            return false;
        }

        var picture = new Picture
        {
            Url = path,
            Owner = user!,
            UserId = user!.Id,
            CreatedOn = DateTime.UtcNow,
            Likes = 0,
            Description = defaultPictureDescriptionChallenge,
            Challenge = challenge,
            ChallengeId = challenge.Id,
        };
        picture.Portfolio.Add(new ApplicationUserPicture()
        {
            UserId = user.Id,
            User = user,
            PictureId = picture.Id,
            Picture = picture
        });

        challenge.Participants++;
        challenge.Pictures.Add(picture);
        await _data.Pictures.AddAsync(picture);
        await _data.SaveChangesAsync();
        return true;
    }
}