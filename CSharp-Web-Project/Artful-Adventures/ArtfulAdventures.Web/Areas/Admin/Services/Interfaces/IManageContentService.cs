namespace ArtfulAdventures.Web.Areas.Admin.Services.Interfaces;

using Models;


/// <summary>
/// Defines the <see cref="IManageContentService" />.
/// </summary>
public interface IManageContentService
{
    /// <summary>
    ///  Definition of delete picture method.
    /// </summary>
    /// <param name="pictureId"> The pictureId <see cref="string"/>.</param>
    /// <param name="user"> The user <see cref="string"/>.</param>
    /// <returns> A string for success or failure. </returns>
    Task<string> DeletePictureAsync(string pictureId, string user);

    /// <summary>
    ///  Definition of delete blog method.
    /// </summary>
    /// <param name="blogId"> The blogId <see cref="string"/>.</param>
    /// <param name="user"> The user <see cref="string"/>.</param>
    Task DeleteBlogAsync(string blogId, string user);

    /// <summary>
    ///  Definition of delete comment method.
    /// </summary>
    /// <param name="pictureId"> The pictureId <see cref="string"/>.</param>
    /// <param name="commentId"> The commentId <see cref="string"/>.</param>
    Task DeleteCommentPictureAsync(string pictureId, string commentId);

    /// <summary>
    ///  Definition of delete comment method.
    /// </summary>
    /// <param name="blogId"> The blogId <see cref="string"/>.</param>
    /// <param name="commentId"> The commentId <see cref="string"/>.</param>
    Task DeleteCommentBlogAsync(string blogId, string commentId);

    /// <summary>
    ///  Definition of create challenge method.
    /// </summary>
    /// <param name="userId"> The userId <see cref="string"/>.</param>
    /// <returns> A challenge create form model. </returns>
    Task<ChallengeCreateFormModel> CreateChallengeGetFormAsync(string userId);

    /// <summary>
    ///  Definition of create challenge method.
    /// </summary>
    /// <param name="model"> The model <see cref="ChallengeCreateFormModel"/>.</param>
    /// <param name="path"> The path for the image <see cref="string"/>.</param>
    /// <returns> An integer for challenge id. </returns>
    Task<int> CreateChallengeAsync(ChallengeCreateFormModel model, string path);

    /// <summary>
    ///  Definition of delete challenge method.
    /// </summary>
    /// <param name="challengeId"> The challengeId <see cref="int"/>.</param>
    /// <returns> A string for success or failure. </returns>
    Task<string> DeleteChallengeAsync(int challengeId);

}

