namespace ArtfulAdventures.Services.Data.Interfaces;

using Web.ViewModels.UserProfile;

/// <summary>
/// Defines the <see cref="IProfileService" />.
/// </summary>
public interface IProfileService
{
    /// <summary>
    /// Provides the ProfileViewModel for the given username.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <param name="userId"> A string for the userId (visiting user).</param>
    /// <returns> A ProfileViewModel.</returns>
    Task<ProfileViewModel?> GetProfileViewModelAsync(string username, string userId);

    /// <summary>
    ///  Provides a method for following a user.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <param name="userId"> A string for the userId (visiting user).</param>
    /// <returns> A string for status message.</returns>
    Task<string> FollowAsync(string username, string userId);

    /// <summary>
    ///  Provides a method for unfollowing a user.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <param name="userId"> A string for the userId (visiting user).</param>
    /// <returns> <see cref="Task"/> </returns>
    Task UnfollowAsync(string username, string userId);
    
    /// <summary>
    ///  Provides a method for getting a user's portfolio.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A PortfolioViewModel.</returns>
    Task<PortfolioViewModel?> GetPortfolioAsync(string username);

    /// <summary>
    ///  Provides a method for getting a user's collection.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A PortfolioViewModel (it uses the same view model).</returns>
    Task<PortfolioViewModel?> GetCollectionAsync(string username);
    
    /// <summary>
    /// Provides a method for getting a user's followers.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A FollowViewModel.</returns>
    Task<FollowViewModel?> GetFollowersAsync(string username);

    /// <summary>
    ///  Provides a method for getting a user's following.
    /// </summary>
    /// <param name="username"> A string for the username.</param>
    /// <returns> A FollowViewModel.</returns>
    Task<FollowViewModel?> GetFollowingAsync(string username);
}

