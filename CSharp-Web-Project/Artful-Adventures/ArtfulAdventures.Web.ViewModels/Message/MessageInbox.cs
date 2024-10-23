namespace ArtfulAdventures.Web.ViewModels.Message;

/// <summary>
///   This class is used to display the user's inbox.
/// </summary>
public class MessageInbox
{
    public ICollection<MessageInboxViewModel> Messages { get; set; } = new List<MessageInboxViewModel>();

    public int TotalUnreadMessages { get; set; }
}

