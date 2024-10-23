using ArtfulAdventures.Data.EnumSeeders;

namespace ArtfulAdventures.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

/// <summary>
/// Configures the seeding of the enums in the database : HashTags and Skills
/// </summary>
public class EnumsSeedingConfiguration : IEntityTypeConfiguration<HashTag>, IEntityTypeConfiguration<Skill>
{
    //Seed HashTags
    public void Configure(EntityTypeBuilder<HashTag> builder)
    {
        builder.HasData(new HashTagsSeed().HashTags);
    }

    //Seed Skills
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasData(new SkillsSeed().Skills);
    }
}

