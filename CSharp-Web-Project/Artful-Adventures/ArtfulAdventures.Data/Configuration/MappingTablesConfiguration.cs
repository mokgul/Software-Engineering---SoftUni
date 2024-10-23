namespace ArtfulAdventures.Data.Configuration;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;

/// <summary>
/// Configuration for the Mapping Tables of the Database (Many to Many Relationships)
/// </summary>
public class MappingTablesConfiguration :
    IEntityTypeConfiguration<ApplicationUserSkill>,
    IEntityTypeConfiguration<ApplicationUserPicture>,
    IEntityTypeConfiguration<ApplicationUserCollection>,
    IEntityTypeConfiguration<PictureHashTag>
{
    //One to many relationship between ApplicationUser and Picture
    //Mapping table for portfolio property of ApplicationUser
    //Usually you dont need to use a mapping table for one to many relationships but in this case I prefer to use one so I dont have to filter the pictures by the user id
    public void Configure(EntityTypeBuilder<ApplicationUserPicture> builder)
    {
        builder.HasKey(ap => new { ap.UserId, ap.PictureId });
    }

    //One to many relationship between ApplicationUser and Collection
    //Mapping table for Collection property of ApplicationUser
    //Usually you dont need to use a mapping table for one to many relationships but in this case I prefer to use one so I dont have to filter the pictures by the user id
    public void Configure(EntityTypeBuilder<ApplicationUserCollection> builder)
    {
        builder.HasKey(ap => new { ap.UserId, ap.PictureId });
    }

    //Many to many relationship between ApplicationUser and Skill
    public void Configure(EntityTypeBuilder<ApplicationUserSkill> builder)
    {
        builder.HasKey(au => new { au.UserId, au.SkillId });
    }

    //Many to many relationship between Picture and HashTag
    public void Configure(EntityTypeBuilder<PictureHashTag> builder)
    {
        builder.HasKey(ph => new { ph.PictureId, ph.TagId });
    }
}


