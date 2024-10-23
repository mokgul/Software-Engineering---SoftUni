namespace ArtfulAdventures.Services.Data.Interfaces;

using Web.ViewModels.Message;

/// <summary>
///  Defines the <see cref="IMessageService"/> interface.
/// </summary>
public interface IMessageService
{
    /// <summary>
    ///  Gets the message send form.
    /// </summary>
    /// <param name="username"> The username of the receiver. </param>
    /// <returns> The <see cref="MessageSendFormModel"/>. </returns>
    Task<MessageSendFormModel> GetSendMessageFormAsync(string username);
    
    /// <summary>
    ///  Sends a message to a user.
    /// </summary>
    /// <param name="model"> The <see cref="MessageSendFormModel"/>. </param>
    /// <param name="userId"> The id of the sender. </param>
    /// <returns> True if the message was sent successfully. </returns>
    Task<bool> SendMessageAsync(MessageSendFormModel model, string userId);
    
    /// <summary>
    ///  Gets the message inbox of a user.
    /// </summary>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="MessageInbox"/>. </returns>
    Task<MessageInbox> GetInboxAsync(string userId);
    
    /// <summary>
    ///  Gets the message inbox view model of a user.
    /// </summary>
    /// <param name="messageId"> The id of the message. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="MessageInboxViewModel"/>. </returns>
    Task<MessageInboxViewModel?> GetInboxViewModelAsync(int messageId, string userId);
    
    /// <summary>
    ///  Gets the message history of between two users.
    /// </summary>
    /// <param name="messageId"> The id of the message. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="MessageInbox"/>. </returns>
    Task<MessageInboxViewModel?> GetMessageHistoryAsync(int messageId, string userId);
    
    /// <summary>
    ///  Gets the message reply form.
    /// </summary>
    /// <param name="messageId"> The id of the message. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="MessageReplyFormModel"/>. </returns>
    Task<MessageReplyFormModel?> GetReplyFormAsync(int messageId, string userId);
}