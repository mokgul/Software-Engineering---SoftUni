namespace ArtfulAdventures.Services.Data;

using System.Threading.Tasks;
using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;
using Common;
using Interfaces;
using Web.ViewModels.Blog;
using Web.ViewModels.Comment;
using Microsoft.EntityFrameworkCore;

/// <summary>
///   This class is responsible for the logic behind the blog posts.
/// </summary>
public class BlogService : IBlogService
{
    private readonly ArtfulAdventuresDbContext _data;

    public BlogService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }

    /// <summary>
    ///  This method returns the blog view model for creating a blog post.
    /// </summary>
    /// <returns></returns>
    public async Task<BlogAddFormModel> GetBlogViewModelAsync()
    {
        var model = new BlogAddFormModel();
        return model;
    }

    /// <summary>
    ///  This method creates a blog post.
    /// </summary>
    /// <param name="model"> The model that contains the blog post information. </param>
    /// <param name="id"> The id of the user that is creating the blog post. </param>
    /// <param name="path"> (Optional) The path to the image that is uploaded. </param>
    public async Task CreateBlogAsync(BlogAddFormModel model, string id, string? path)
    {
        var user = await GetUser(id);
        var blog = new Blog
        {
            Id = Guid.NewGuid(),
            Title = model.Title,
            Content = model.Content,
            Author = user!,
            AuthorId = user!.Id,
            CreatedOn = DateTime.UtcNow,
            Likes = 0,
            ImageUrl = path,
        };
        await _data.Blogs.AddAsync(blog);
        await _data.SaveChangesAsync();
    }

    /// <summary>
    ///  This method returns the blog details view model.
    /// </summary>
    /// <param name="id"> The id of the blog post. </param>
    /// <param name="currentUser"> The id of the current user. </param>
    /// <returns> The blog details view model. </returns>
    public async Task<BlogDetailsViewModel?> GetBlogDetailsAsync(string id, string currentUser)
    {
        var userCommenting = await _data.Users
            .FirstOrDefaultAsync(x => x.Id.ToString() == currentUser);

        var userMute = userCommenting!.MuteUntil != null && userCommenting.MuteUntil > DateTime.UtcNow;

        var blog = await _data.Blogs
            .Include(a => a.Author)
            .Include(c => c.Comments)
            .Where(x => x.Id.ToString() == id.ToLower())
            .Select(blog => new BlogDetailsViewModel()
            {
                Id = blog.Id.ToString(),
                Title = blog.Title,
                Content = blog.Content,
                Author = blog.Author.UserName,
                CreatedOn = blog.CreatedOn,
                Likes = blog.Likes,
                ImageUrl = Path.GetFileName(blog.ImageUrl),
                isCurrentUserMuted = userMute,
                CommentsCount = blog.Comments.Count,
                Comments = blog.Comments.Select(c => new CommentViewModel()
                {
                    Id = c.Id,
                    Author = c.Author,
                    Content = c.Content,
                    CreatedOn = c.CreatedOn,
                }).ToList()
            })
            .FirstOrDefaultAsync();

        if (blog == null)
        {
            return null;
        }

        foreach (var comment in blog.Comments)
        {
            comment.AuthorPictureUrl =
                Path.GetFileName(_data.Users.FirstOrDefault(u => u.UserName == comment.Author)?.Url);
        }

        return blog;
    }

    /// <summary>
    ///  This method returns a list of blogs that are sorted by the given parameter.
    /// </summary>
    /// <param name="sort"> The parameter by which the blogs are sorted. </param>
    /// <param name="page"> The page number. </param>
    /// <returns> The list of blogs. </returns>
    public async Task<BlogVisualizeModel?> GetAllBlogsAsync(string sort, int page = 1)
    {
        if (!ValidatePage.Validate(page))
        {
            return null;
        }

        const int pageSize = 6;
        var skip = (page - 1) * pageSize;

        var blogs = await _data.Blogs
            .Include(a => a.Author)
            .OrderByDescending(x => x.CreatedOn)
            .Skip(skip)
            .Take(pageSize)
            .Select(b => new BlogDetailsViewModel()
            {
                Id = b.Id.ToString(),
                Title = b.Title,
                Content = b.Content,
                Author = b.Author.UserName,
                CreatedOn = b.CreatedOn,
                Likes = b.Likes,
                ImageUrl = Path.GetFileName(b.ImageUrl),
            })
            .ToListAsync();

        blogs = await SortBlogsAsync(sort, blogs);
        var model = new BlogVisualizeModel()
        {
            Blogs = blogs
        };

        return model;
    }

    /// <summary>
    ///  This method updates the likes of a blog post.
    /// </summary>
    /// <param name="blogId"> The id of the blog post. </param>
    public async Task<bool> LikeBlogAsync(string blogId)
    {
        var blog = await _data.Blogs.FirstOrDefaultAsync(x => x.Id.ToString() == blogId);
        var success = true;
        if (blog == null)
        {
            success = false;
            return success;
        }

        blog.Likes++;
        await _data.SaveChangesAsync();
        return success;
    }


    /// <summary>
    ///  This method gets the blog post that is to be edited.
    /// </summary>
    /// <param name="id"> The id of the blog post. </param>
    /// <returns> The blog post that is to be edited. </returns>
    public async Task<BlogAddFormModel?> GetBlogToEditAsync(string id)
    {
        var blog = await _data.Blogs
            .Include(u => u.Author)
            .Where(x => x.Id.ToString() == id)
            .Select(b => new BlogAddFormModel()
            {
                Id = b.Id.ToString(),
                Title = b.Title,
                Content = b.Content,
                ImageUrl = Path.GetFileName(b.ImageUrl),
            })
            .FirstOrDefaultAsync();

        return blog ?? null;
    }

    /// <summary>
    ///  This method returns a collection of blogs for the current user.
    /// </summary>
    /// <param name="sort"> The parameter by which the blogs are sorted. </param>
    /// <param name="userId"> The id of the current user. </param>
    /// <param name="page"> The page number. </param>
    /// <returns> The collection of blogs. </returns>
    public async Task<BlogVisualizeModel?> GetAllBlogsForManageAsync(string sort, string userId, int page = 1)
    {
        if (!ValidatePage.Validate(page))
        {
            return null;
        }

        const int pageSize = 6;
        var skip = (page - 1) * pageSize;

        var blogs = await _data.Blogs
            .Include(a => a.Author)
            .Where(b => b.AuthorId.ToString() == userId)
            .OrderByDescending(x => x.CreatedOn)
            .Skip(skip)
            .Take(pageSize)
            .Select(b => new BlogDetailsViewModel()
            {
                Id = b.Id.ToString(),
                Title = b.Title,
                Content = b.Content,
                Author = b.Author.UserName,
                CreatedOn = b.CreatedOn,
                Likes = b.Likes,
                ImageUrl = Path.GetFileName(b.ImageUrl),
            })
            .ToListAsync();

        blogs = await SortBlogsAsync(sort, blogs);
        var model = new BlogVisualizeModel()
        {
            Blogs = blogs,
        };

        return model;
    }
    
    /// <summary>
    ///  This method edits a blog post.
    /// </summary>
    /// <param name="model"></param>
    /// <param name="id"></param>
    /// <param name="path"></param>
    public async Task EditBlogAsync(BlogAddFormModel model, string id, string? path)
    {
        var blog = await _data.Blogs
            .FirstOrDefaultAsync(x => x.Id.ToString() == id)!;
        
        blog!.Title = model.Title;
        blog.Content = model.Content;
        if (!string.IsNullOrEmpty(path))
        {
            blog.ImageUrl = path;
        }

        _data.Blogs.Update(blog);
        await _data.SaveChangesAsync();
    }
    
    /// <summary>
    ///  This method deletes a blog post.
    /// </summary>
    /// <param name="id"> The id of the blog post. </param>
    /// <param name="userId"> The id of the current user. </param>
    public async Task DeleteBlogAsync(string id, string userId)
    {
        var blog = await _data.Blogs
            .Include(c => c.Comments)
            .Where(u => u.AuthorId.ToString() == userId)
            .FirstOrDefaultAsync(x => x.Id.ToString() == id);
        
        blog!.Comments.Clear();
        _data.Blogs.Remove(blog!);
        await _data.SaveChangesAsync();
    }

    /// <summary>
    ///  This method returns a user by id.
    /// </summary>
    /// <param name="userId"> The id of the user. </param>
    private async Task<ApplicationUser?> GetUser(string userId)
    {
        return await _data.Users
            .Include(m => m.Blogs)
            .FirstOrDefaultAsync(u => u.Id.ToString() == userId);
    }

    /// <summary>
    ///  This method sorts the blogs by the given parameter and returns them.
    /// </summary>
    /// <param name="sort"> The parameter by which the blogs are sorted. </param>
    /// <param name="blogs"> The collection of blogs. </param>
    /// <returns> The sorted collection of blogs. </returns>
    /// <exception cref="ArgumentException"></exception>
    private async Task<List<BlogDetailsViewModel>> SortBlogsAsync(string sort, List<BlogDetailsViewModel> blogs)
    {
        if (string.IsNullOrWhiteSpace(sort))
        {
            return blogs;
        }
        // Validate sort parameter
        var sortValidator = new ValidateSortParameter(_data);
        var isValid = await sortValidator.Validate(sort);
        if (!isValid)
        {
            throw new ArgumentException("Invalid sort parameter!");
        }

        var owner = string.Empty;
        if (sort != "likes" && sort != "newest" && sort != "oldest")
        {
            owner = sort;
            sort = "author";
            if (!_data.Users.Any(u => u.UserName == owner))
                throw new ArgumentException($"User {owner} does not exist.");

            if (blogs.Count(p => p.Author == owner) == 0)
                throw new ArgumentException($"{owner} has not published any blogs yet.");
        }

        // Sort blogs
        switch (sort)
        {
            case "likes":
                blogs = blogs.OrderByDescending(p => p.Likes).ToList();
                break;
            case "newest":
                blogs = blogs.OrderByDescending(p => p.CreatedOn).ToList();
                break;
            case "oldest":
                blogs = blogs.OrderBy(p => p.CreatedOn).ToList();
                break;
            case "author":
                blogs = blogs.Where(p => p.Author == owner).ToList();
                break;
            default:
                break;
        }

        return blogs;
    }


    

    
}