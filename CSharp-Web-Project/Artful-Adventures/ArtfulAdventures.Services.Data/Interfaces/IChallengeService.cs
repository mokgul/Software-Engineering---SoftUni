namespace ArtfulAdventures.Services.Data.Interfaces;

using Web.ViewModels.Challenges;

/// <summary>
///  Defines the <see cref="IChallengeService" />.
/// </summary>
public interface IChallengeService
{
    /// <summary>
    ///  Provides a method for getting the challenge view model.
    /// </summary>
    /// <param name="page"> Аn int for the page number. </param>
    /// <returns> The <see cref="Task{ChallengeAddFormModel}"/>. </returns>
    Task<ChallengesViewModel?> GetAllAsync(int page);

    /// <summary>
    ///  Provides a method for getting the challenge view model.
    /// </summary>
    /// <param name="id"> The id of the challenge. </param>
    /// <returns> The <see cref="Task{ChallengeAddFormModel}"/>. </returns>
    Task<ChallengeDetailsViewModel?> GetChallengeDetailsAsync(int id);

    /// <summary>
    ///  Provides a method for participating in a challenge.
    /// </summary>
    /// <param name="id"> The id of the challenge. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <param name="path"> The path to the image. </param>
    /// <returns> The bool for the result. </returns>
    Task<bool> ParticipateAsync(int id, string userId, string path);
}

