namespace Homies.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Homies.Data.Entities;

public class HomiesDbContext : IdentityDbContext
{
    public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
        : base(options)
    {
    }

    public DbSet<Entities.Type> Types { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<EventParticipant> EventsParticipants { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventParticipant>(entity =>
        {
            entity.HasKey(ep => new { ep.HelperId, ep.EventId });
        });

        modelBuilder
            .Entity<Entities.Type>()
            .HasData(new Entities.Type()
            {
                Id = 1,
                Name = "Animals"
            },
            new Entities.Type()
            {
                Id = 2,
                Name = "Fun"
            },
            new Entities.Type()
            {
                Id = 3,
                Name = "Discussion"
            },
            new Entities.Type()
            {
                Id = 4,
                Name = "Work"
            });

        base.OnModelCreating(modelBuilder);
    }
}
