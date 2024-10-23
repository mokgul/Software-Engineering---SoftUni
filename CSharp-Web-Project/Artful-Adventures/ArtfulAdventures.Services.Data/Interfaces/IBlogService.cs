namespace ArtfulAdventures.Services.Data.Interfaces;

using Web.ViewModels.Blog;

/// <summary>
///  Defines the <see cref="IBlogService" />.
/// </summary>
public interface IBlogService
{
    /// <summary>
    /// Provides a method for getting the blog view model.
    /// </summary>
    /// <returns> The <see cref="Task{BlogAddFormModel}"/>.
    /// </returns>
    Task<BlogAddFormModel> GetBlogViewModelAsync();

    /// <summary>
    /// Provides a method for creating a blog.
    /// </summary>
    /// <param name="model"> The model <see cref="BlogAddFormModel"/> for blog creation. </param>
    /// <param name="id"> The id of the user creating the blog. </param>
    /// <param name="path"> (Optional) The path to the image. </param>
    /// <returns> <see cref="Task"/>. </returns>
    Task CreateBlogAsync(BlogAddFormModel model, string id, string? path);

    /// <summary>
    ///  Provides a method for getting the blog details.
    /// </summary>
    /// <param name="id"> The id of the blog. </param>
    /// <param name="currentUser"> The current user (username). </param>
    /// <returns> The <see cref="Task{BlogDetailsViewModel}"/>. </returns>
    Task<BlogDetailsViewModel?> GetBlogDetailsAsync(string id, string currentUser);

    /// <summary>
    ///  Provides a method for getting all blogs.
    /// </summary>
    /// <param name="sort"> A string for sorting the blogs. </param>
    /// <param name="page"> An int for the page number. </param>
    /// <returns> The <see cref="Task{BlogVisualizeModel}"/>. </returns>
    Task<BlogVisualizeModel?> GetAllBlogsAsync(string sort, int page);

    /// <summary>
    ///  Provides a method for getting all blogs for the user.
    /// </summary>
    /// <param name="sort"> A string for sorting the blogs. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <param name="page"> An int for the page number. </param>
    /// <returns> The <see cref="Task{BlogVisualizeModel}"/>. </returns>
    Task<BlogVisualizeModel?> GetAllBlogsForManageAsync(string sort, string userId, int page);

    /// <summary>
    ///  Provides a method for getting the blog to edit.
    /// </summary>
    /// <param name="id"> The id of the blog. </param>
    /// <returns> The <see cref="Task{BlogAddFormModel}"/>. </returns>
    Task<BlogAddFormModel?> GetBlogToEditAsync(string id);

    /// <summary>
    ///  Provides a method for editing the blog.
    /// </summary>
    /// <param name="model"> The model <see cref="BlogAddFormModel"/> for blog editing. </param>
    /// <param name="id"> The id of the blog. </param>
    /// <param name="path"> (Optional) The path to the image. </param>
    /// <returns> The <see cref="Task"/>. </returns>
    Task EditBlogAsync(BlogAddFormModel model, string id, string? path);
    
    /// <summary>
    ///  Provides a method for deleting the blog.
    /// </summary>
    /// <param name="id"> The id of the blog. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="Task"/>. </returns>
    Task DeleteBlogAsync(string id, string userId);
    
    /// <summary>
    ///  Provides a method for liking the blog.
    /// </summary>
    /// <param name="blogId"> The id of the blog. </param>
    /// <returns> The <see cref="Task"/>. </returns>
    Task<bool> LikeBlogAsync(string blogId);
}

