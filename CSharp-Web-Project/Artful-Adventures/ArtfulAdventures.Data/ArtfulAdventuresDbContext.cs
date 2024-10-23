namespace ArtfulAdventures.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Configuration;
using Models;

public class ArtfulAdventuresDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ArtfulAdventuresDbContext(DbContextOptions<ArtfulAdventuresDbContext> options)
        : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; } = null!;

    public DbSet<Challenge> Challenges { get; set; } = null!;

    public DbSet<Comment> Comments { get; set; } = null!;

    public DbSet<HashTag> HashTags { get; set; } = null!;

    public DbSet<Picture> Pictures { get; set; } = null!;

    public DbSet<Skill> Skills { get; set; } = null!;
    

    public DbSet<PictureHashTag> PicturesHashTags { get; set; } = null!;

    public DbSet<ApplicationUserSkill> ApplicationUsersSkills { get; set; } = null!;
    

    public DbSet<ApplicationUserPicture> Portfolio { get; set; } = null!;
    

    public DbSet<ApplicationUserCollection> Collection { get; set; } = null!;
    

    public DbSet<FollowerFollowing> Follows { get; set; } = null!;

    public DbSet<Message> Messages { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        ConfigureMappingTables(builder);
       
        ConfigureEnums(builder);

        ConfigureFollowTable(builder);
        
        ConfigureMessageTable(builder);

        ConfigureRoles(builder);

        ConfigureUsers(builder);

        base.OnModelCreating(builder);
    }

    //Configure the mapping tables
    private static void ConfigureMappingTables(ModelBuilder builder)
    {
        var mappingConfigure = new MappingTablesConfiguration();
        
        builder.ApplyConfiguration<PictureHashTag>(mappingConfigure);
        builder.ApplyConfiguration<ApplicationUserSkill>(mappingConfigure);
        builder.ApplyConfiguration<ApplicationUserPicture>(mappingConfigure);
        builder.ApplyConfiguration<ApplicationUserCollection>(mappingConfigure);
    }
    
    //Configure the enums
    private static void ConfigureEnums(ModelBuilder builder)
    {
        var enumSeedConfigure = new EnumsSeedingConfiguration();
        
        builder.ApplyConfiguration<HashTag>(enumSeedConfigure);
        builder.ApplyConfiguration<Skill>(enumSeedConfigure);
    }
    
    //Configure following table
    private static void ConfigureFollowTable(ModelBuilder builder)
    {
        var followTableConfiguration = new FollowTableConfiguration();
        
        builder.ApplyConfiguration<FollowerFollowing>(followTableConfiguration);
    }
    
    //Configure the message table
    private static void ConfigureMessageTable(ModelBuilder builder)
    {
        var messageConfiguration = new MessageTableConfiguration();
        
        builder.ApplyConfiguration<Message>(messageConfiguration);
    }
    
    //Configure roles
    private static void ConfigureRoles(ModelBuilder builder)
    {
        var roleConfiguration = new CreateRolesConfiguration();
        
        builder.ApplyConfiguration<IdentityRole<Guid>>(roleConfiguration);
    }
    
    //Configure the users and add roles to them
    private static void ConfigureUsers(ModelBuilder builder)
    {
        var userConfiguration = new SeedUsersConfiguration();
        
        builder.ApplyConfiguration<ApplicationUser>(userConfiguration);
        builder.ApplyConfiguration<IdentityUserRole<Guid>>(userConfiguration);
    }
}
