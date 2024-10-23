namespace ArtfulAdventures.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

/// <summary>
/// Configuration for the Message Table
/// </summary>
public class MessageTableConfiguration : IEntityTypeConfiguration<Message>
{
    //Configure the Message Table
    public void Configure(EntityTypeBuilder<Message> builder)
    {
        //Fluent API for SentMessages of the ApplicationUser
        builder
         .HasOne(m => m.Sender)
         .WithMany(u => u.SentMessages)
         .HasForeignKey(m => m.SenderId);

        //Fluent API for ReceivedMessages of the ApplicationUser
        builder
            .HasOne(m => m.Receiver)
            .WithMany(u => u.ReceivedMessages)
            .HasForeignKey(m => m.ReceiverId);
    }
}
