namespace ArtfulAdventures.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

/// <summary>
/// Configuration for the Follow Mapping Table
/// </summary>
public class FollowTableConfiguration : IEntityTypeConfiguration<FollowerFollowing>
{
    //Configure the Follow Mapping Table
    public void Configure(EntityTypeBuilder<FollowerFollowing> builder)
    {
        //Fluent API for the Follow Mapping Table
        builder
            .HasKey(f => new { f.FollowerId, f.FollowedId });

        //Fluent API for the Following Property of the ApplicationUser
        builder
            .HasOne(f => f.Follower)
            .WithMany(u => u.Following)
            .HasForeignKey(f => f.FollowerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        //Fluent API for the Followers Property of the ApplicationUser
        builder
            .HasOne(f => f.Followed)
            .WithMany(u => u.Followers)
            .HasForeignKey(f => f.FollowedId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

