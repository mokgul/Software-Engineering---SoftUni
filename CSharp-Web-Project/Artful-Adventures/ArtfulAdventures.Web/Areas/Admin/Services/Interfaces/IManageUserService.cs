namespace ArtfulAdventures.Web.Areas.Admin.Services.Interfaces;

using Models;

/// <summary>
/// Defines the <see cref="IManageContentService" />.
/// </summary>
public interface IManageUserService
{
    /// <summary>
    ///  Definition of Promote to admin method.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A string for success or failure. </returns>
    Task PromoteToAdminAsync(string username);

    
    /// <summary>
    ///  Definition of Demote admin method.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A string for success or failure. </returns>
    Task DemoteAdminAsync(string username);

    
    /// <summary>
    ///  Definition of Set default role method.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A string for success or failure. </returns>
    Task SetDefaultRoleAsync(string username);
    
    
    /// <summary>
    ///  Definition of Mute user method.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <param name="days"> The days <see cref="int"/>.</param>
    /// <param name="admin"> The admin <see cref="string"/>.</param>
    /// <returns></returns>
    Task MuteUserAsync(string username, int days, string admin);
    
    
    /// <summary>
    ///  Definition of Unmute user method.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    Task UnmuteUserAsync(string username);
    
    
    /// <summary>
    ///  Definition of Ban user method.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns></returns>
    Task BanUserAsync(string username);
    
    
    /// <summary>
    ///  Definition of Unban user method.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    Task UnbanUserAsync(string username);

    
    /// <summary>
    ///  Definition of Get users method.
    /// </summary>
    /// <param name="username"> The username <see cref="string"/>.</param>
    /// <returns> A collection of user view models. </returns>
    Task<ICollection<UserViewModel>> GetUserAsync(string username);

    
    /// <summary>
    ///  Definition of Get all users method.
    /// </summary>
    /// <param name="page"> The page <see cref="int"/>.</param>
    /// <returns> A collection of user view models. </returns>
    Task<ICollection<UserViewModel>> GetAllUsersAsync(int page);

    
    /// <summary>
    ///  Definition of Get all admins method.
    /// </summary>
    /// <returns> A collection of user view models. </returns>
    Task<ICollection<UserViewModel>> GetAllAdminsAsync();
    
    
    /// <summary>
    ///  Definition of Get all muted users method.
    /// </summary>
    /// <returns> A collection of user view models. </returns>
    Task<ICollection<UserViewModel>> GetAllMutedUsersAsync();
    
    
    /// <summary>
    ///  Definition of Get all banned users method.
    /// </summary>
    /// <returns> A collection of user view models. </returns>
    Task<ICollection<UserViewModel>> GetAllBannedUsersAsync();
    
}

