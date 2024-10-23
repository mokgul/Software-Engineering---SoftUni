namespace ArtfulAdventures.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Common.DataModelsValidationConstants.MessageConstants;

/// <summary>
/// Represents a message sent from one user to another.
/// </summary>
public class Message
    {
    public int Id { get; set; }

    [Required]
    [ForeignKey(nameof(Sender))]
    public Guid SenderId { get; set; }

    public ApplicationUser Sender { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Receiver))]
    public Guid ReceiverId { get; set; }

    public ApplicationUser Receiver { get; set; } = null!;

    [Required]
    [MaxLength(SubjectMaxLength)]
    public string Subject { get; set; } = null!;

    [Required]
    [MaxLength(ContentMaxLength)]
    public string Content { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime Timestamp { get; set; }

    }

