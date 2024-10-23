using Forum.Data;
using Forum.Data.Models;
using Forum.Services.Interfaces;
using ForumViewModels.Post;
using Microsoft.EntityFrameworkCore;

namespace Forum.Services
{
    public class PostService : IPostService
    {
        private readonly ForumAppDbContext _dbContext;

        public PostService(ForumAppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IEnumerable<PostListViewModel>> ListAllAsync()
        {
            IEnumerable<PostListViewModel> allPosts = await _dbContext
                .Posts
                .Select(p => new PostListViewModel()
                {
                    Id = p.Id.ToString(),
                    Title = p.Title,
                    Content = p.Content,
                })
                .ToArrayAsync();

            return allPosts;
        }

        public async Task AddPostAsync(PostFormModel postViewModel)
        {
            Post newPost = new Post()
            {
                Title = postViewModel.Title,
                Content = postViewModel.Content,
            };
            await this._dbContext.Posts.AddAsync(newPost);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<PostFormModel> GetItemForEditOrDelete(string id)
        {
            Post post = await _dbContext.Posts.FirstAsync(p => p.Id.ToString() == id);

            return new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content,
            };
        }

        public async Task EditByIdAsync(string id, PostFormModel postEditModel)
        {
            Post postToEdit = await _dbContext.Posts.FirstAsync(p => p.Id.ToString() == id);

            postToEdit.Title = postEditModel.Title;
            postToEdit.Content = postEditModel.Content;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            Post postToDelete = await _dbContext.Posts.FirstAsync(p => p.Id.ToString() == id);

            _dbContext.Posts.Remove(postToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}