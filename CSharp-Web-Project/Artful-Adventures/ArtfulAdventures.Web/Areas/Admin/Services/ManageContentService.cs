namespace ArtfulAdventures.Web.Areas.Admin.Services;

using System.Threading.Tasks;

using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;
using ArtfulAdventures.Web.Areas.Admin.Models;
using ArtfulAdventures.Web.Areas.Admin.Services.Interfaces;

using Microsoft.EntityFrameworkCore;

public class ManageContentService : IManageContentService
{
    private readonly ArtfulAdventuresDbContext _data;

    public ManageContentService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }

    public async Task<int> CreateChallengeAsync(ChallengeCreateFormModel model, string path)
    {
        Challenge challenge = new Challenge()
        {
            CreatedOn = model.CreatedOn,
            Creator = model.Creator,
            Title = model.Title,
            Url = path,
            Requirements = model.Requirements,
            Participants = 0
        };
        await _data.Challenges.AddAsync(challenge);
        await _data.SaveChangesAsync();
        return challenge.Id;
    }

    public async Task<ChallengeCreateFormModel> CreateChallengeGetFormAsync(string userId)
    {
        var user = await _data.Users.FirstOrDefaultAsync(x => x.Id.ToString() == userId);
        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }
        var model = new ChallengeCreateFormModel
        {
            CreatedOn = DateTime.UtcNow,
            Creator = user.UserName,
        };
        return model;
    }

    public async Task DeleteBlogAsync(string blogId, string user)
    {
        var blog = await _data.Blogs
            .Include(c => c.Comments)
            .Include(o => o.Author)
            .Where(u => u.Author.UserName == user)
            .FirstOrDefaultAsync(p => p.Id.ToString() == blogId);
        if (blog == null)
        {
            throw new ArgumentException("Blog not found.");
        }
        _data.Blogs.Remove(blog);
        await _data.SaveChangesAsync();
    }

    public async Task<string> DeleteChallengeAsync(int challengeId)
    {
        var challenge = await _data.Challenges.FirstOrDefaultAsync(x => x.Id == challengeId);
        if (challenge == null)
        {
            throw new ArgumentException("Challenge not found.");
        }
        var path = challenge.Url;
        _data.Challenges.Remove(challenge);
        await _data.SaveChangesAsync();
        return path;
    }

    public async Task DeleteCommentBlogAsync(string blogId, string commentId)
    {
        var comment = await _data.Comments.FirstOrDefaultAsync(x => x.Id.ToString() == commentId);
        if (comment == null)
        {
            throw new ArgumentException("Comment not found.");
        }
        _data.Comments.Remove(comment);
        await _data.SaveChangesAsync();
    }

    public async Task DeleteCommentPictureAsync(string pictureId, string commentId)
    {

        var comment = await _data.Comments.FirstOrDefaultAsync(x => x.Id.ToString() == commentId);
        if (comment == null)
        {
            throw new ArgumentException("Comment not found.");
        }
        _data.Comments.Remove(comment);
        await _data.SaveChangesAsync();
    }

    public async Task<string> DeletePictureAsync(string pictureId, string user)
    {
        var path = string.Empty;
        var userId = await _data.Users
            .Where(u => u.UserName == user)
            .Select(u => u.Id.ToString())
            .FirstOrDefaultAsync();
        if (userId == null)
        {
            throw new ArgumentException("User not found.");
        }
        var picture = await _data.Pictures
            .Include(c => c.Comments)
            .Include(cl => cl.Collection)
            .Include(ph => ph.PicturesHashTags)
            .Include(p => p.Portfolio)
            .Include(o => o.Owner)
            .Where(u => u.Owner.Id.ToString() == userId)
            .FirstOrDefaultAsync(p => p.Id.ToString() == pictureId);
        if (picture == null)
        {
            throw new ArgumentException("Picture not found.");
        }
        picture!.Comments.Clear();
        picture.Collection.Clear();
        picture.PicturesHashTags.Clear();
        picture.Portfolio.Clear();

        path = picture.Url;

        _data.Pictures.Remove(picture);
        await _data.SaveChangesAsync();

        return path;
    }
}



