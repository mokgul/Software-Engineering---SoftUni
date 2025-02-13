﻿namespace ArtfulAdventures.Web.ViewModels.Message;

using System.ComponentModel.DataAnnotations;

using static Common.DataModelsValidationConstants.MessageConstants;

/// <summary>
///  This view model is used to display the message reply form.
/// </summary>
public class MessageReplyFormModel
{
    [Required]
    [StringLength(SubjectMaxLength, MinimumLength = SubjectMinLength)]
    public string Subject { get; set; } = null!;

    [Required]
    [StringLength(ContentMaxLength, MinimumLength = ContentMinLength)]
    public string Content { get; set; } = null!;

    public string Receiver { get; set; } = null!;

    public ICollection<MessageInboxViewModel> MessagesHistory { get; set; } = new List<MessageInboxViewModel>();
}

