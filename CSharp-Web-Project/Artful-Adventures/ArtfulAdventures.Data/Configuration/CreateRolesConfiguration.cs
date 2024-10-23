namespace ArtfulAdventures.Data.Configuration;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using static Common.DataModelsValidationConstants.RolesConstants;

/// <summary>
/// Configuration for IdentityUserRole
/// </summary>
public class CreateRolesConfiguration : IEntityTypeConfiguration<IdentityRole<Guid>>
{
    // Seed Roles
    public void Configure(EntityTypeBuilder<IdentityRole<Guid>> builder)
    {
        builder
            .HasData(new IdentityRole<Guid> { Id = Guid.Parse(AdminId), Name = "Administrator", NormalizedName = "ADMINISTRATOR" });
        
        builder
            .HasData(new IdentityRole<Guid> { Id = Guid.Parse(UserId), Name = "User", NormalizedName = "USER" });
    }
}
