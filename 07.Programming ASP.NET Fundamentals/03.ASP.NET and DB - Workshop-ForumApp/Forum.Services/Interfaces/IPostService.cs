using ForumViewModels.Post;

namespace Forum.Services.Interfaces;

public interface IPostService
{
    Task<IEnumerable<PostListViewModel>> ListAllAsync();

    Task AddPostAsync(PostFormModel postViewModel);

    Task<PostFormModel> GetItemForEditOrDelete(string id);

    Task EditByIdAsync(string id, PostFormModel postEditModel);

    Task DeleteByIdAsync(string id);
}