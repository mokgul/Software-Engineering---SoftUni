namespace ArtfulAdventures.Services.Data;

using Microsoft.EntityFrameworkCore;

using ArtfulAdventures.Data;
using ArtfulAdventures.Data.Models;
using Interfaces;
using Web.ViewModels.Message;

/// <summary>
///   This class is used to send messages between users.
/// </summary>
public class MessageService : IMessageService
{
    private readonly ArtfulAdventuresDbContext _data;

    public MessageService(ArtfulAdventuresDbContext data)
    {
        _data = data;
    }
    
    /// <summary>
    ///  Gets the message send form.
    /// </summary>
    /// <param name="username"> The username of the receiver. </param>
    /// <returns> The <see cref="MessageSendFormModel"/>. </returns>
    public async Task<MessageSendFormModel> GetSendMessageFormAsync(string username)
    {
        var model = new MessageSendFormModel
        {
            Receiver = username
        };
        return model;
    }

    /// <summary>
    ///  Sends a message to a user.
    /// </summary>
    /// <param name="model"> The <see cref="MessageSendFormModel"/>. </param>
    /// <param name="userId"> The id of the sender. </param>
    /// <returns> True if the message was sent successfully. </returns>
    public async Task<bool> SendMessageAsync(MessageSendFormModel model, string userId)
    {
        var receiver = await _data.Users
            .FirstOrDefaultAsync(x => x.UserName == model.Receiver);
        if (receiver == null)
        {
            return false;
        }
        var user = await _data.Users
            .FirstOrDefaultAsync(x => x.Id.ToString() == userId);
        
        var message = new Message()
        {
            Sender = user!,
            SenderId = user!.Id,
            Receiver = receiver,
            ReceiverId = receiver.Id,
            Subject = model.Subject,
            Content = model.Content,
            Timestamp = DateTime.UtcNow,
        };
        user.SentMessages.Add(message);
        receiver.ReceivedMessages.Add(message);
        await _data.Messages.AddAsync(message);
        await _data.SaveChangesAsync();
        return true;
    }

    /// <summary>
    ///  Gets the inbox of a user.
    /// </summary>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="MessageInbox"/>. </returns>
    public async Task<MessageInbox> GetInboxAsync(string userId)
    {
        var messages = await _data.Messages
            .Include(s => s.Sender)
            .Include(r => r.Receiver)
            .Where(m => m.Receiver.Id.ToString() == userId)
            .ToListAsync();

        var groupedMessages = messages
            .GroupBy(m => m.Sender.UserName)
            .Select(g => new
            {
                Sender = g.Key,
                LatestMessage = g.MaxBy(m => m.Timestamp),
                UnreadCount = g.Count(m => !m.IsRead)
            })
            .ToList();

        var inboxMessages = groupedMessages
            .Select(g => new MessageInboxViewModel
            {
                Id = g.LatestMessage!.Id,
                Subject = g.LatestMessage.Subject,
                Content = g.LatestMessage.Content,
                Sender = g.Sender,
                Receiver = g.LatestMessage.Receiver.UserName,
                Timestamp = g.LatestMessage.Timestamp,
                IsRead = g.LatestMessage.IsRead,
                UnreadMessages = g.UnreadCount
            })
            .ToList();

        var model = new MessageInbox
        {
            Messages = inboxMessages,
            TotalUnreadMessages = inboxMessages.Sum(m => m.UnreadMessages)
        };
        return model;
    }

    
    /// <summary>
    ///  Gets the sent messages of a user.
    /// </summary>
    /// <param name="messageId"> The id of the message. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="MessageInboxViewModel"/>. </returns>
    public async Task<MessageInboxViewModel?> GetInboxViewModelAsync(int messageId, string userId)
    {
        var message = await _data.Messages
            .Include(s => s.Sender)
            .Include(r => r.Receiver)
            .FirstOrDefaultAsync(m => m.Id == messageId);
        if (message == null)
        {
            return null;
        }

        message.IsRead = true;
        await _data.SaveChangesAsync();
        var model = new MessageInboxViewModel
        {
            Id = message.Id,
            Subject = message.Subject,
            Content = message.Content,
            Sender = message.Sender.UserName,
            Receiver = message.Receiver.UserName,
            Timestamp = message.Timestamp,
            IsRead = message.IsRead
        };
        return model;
    }

    
    /// <summary>
    ///  Gets the message history between two users.
    /// </summary>
    /// <param name="messageId"> The id of the message. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="MessageInboxViewModel"/>. </returns>
    public async Task<MessageInboxViewModel?> GetMessageHistoryAsync(int messageId, string userId)
    {
        
        var message = await _data.Messages
            .Include(s => s.Sender)
            .Include(r => r.Receiver)
            .Where(s => s.Sender.Id.ToString() != userId)
            .OrderByDescending(t => t.Timestamp)
            .FirstOrDefaultAsync(m => m.Id == messageId);
        
        if (message == null)
        {
            return null;
        }

        var secondUser = message.Sender.Id.ToString() == userId ? message.Receiver.UserName : message.Sender.UserName;
        var messagesHistory = await _data.Messages
            .Where(m => (m.Sender.Id.ToString() == userId && m.Receiver.UserName == secondUser) ||
                        (m.Sender.UserName == secondUser && m.Receiver.Id.ToString() == userId))
            .Select(m => new MessageInboxViewModel
            {
                Id = m.Id,
                Subject = m.Subject,
                Content = m.Content,
                Sender = m.Sender.UserName,
                Receiver = m.Receiver.UserName,
                Timestamp = m.Timestamp,
                IsRead = m.IsRead
            })
            .OrderByDescending(m => m.Timestamp)
            .ToListAsync();
        var model = new MessageInboxViewModel()
        {
            Id = message.Id,
            Subject = message.Subject,
            Content = message.Content,
            Sender = message.Sender.UserName,
            Receiver = message.Receiver.UserName,
            Timestamp = message.Timestamp,
            IsRead = message.IsRead,
            MessagesHistory = messagesHistory
        };
        return model;
    }

    
    /// <summary>
    ///  Gets the reply message form of a user.
    /// </summary>
    /// <param name="messageId"> The id of the message. </param>
    /// <param name="userId"> The id of the user. </param>
    /// <returns> The <see cref="MessageReplyFormModel"/>. </returns>
    public async Task<MessageReplyFormModel?> GetReplyFormAsync(int messageId, string userId)
    {
        var message = await _data.Messages
            .Include(s => s.Sender)
            .FirstOrDefaultAsync(x => x.Id == messageId);
        
        if (message == null)
        {
            return null;
        }
        
        var model = new MessageReplyFormModel()
        {
            Receiver = message.Sender.UserName,
            Subject = message.Subject,
            Content = string.Empty,
        };
        return model;
    }
}