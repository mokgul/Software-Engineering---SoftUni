using Microsoft.EntityFrameworkCore;
using P02_FootballBetting.Data.Common;
using P02_FootballBetting.Data.Models;

namespace P02_FootballBetting.Data;

public class FootballBettingContext : DbContext
{
    public FootballBettingContext()
    {
        
    }

    public FootballBettingContext(DbContextOptions options) : base (options)
    {
        
    }

    public DbSet<Bet> Bets { get; set; } = null!;

    public DbSet<Color> Colors { get; set; } = null!;

    public DbSet<Country> Countries { get; set; } = null!;

    public DbSet<Game> Games { get; set; } = null!;

    public DbSet<Player> Players { get; set; } = null!;

    public DbSet<PlayerStatistic> PlayersStatistics { get; set; } = null!;

    public DbSet<Position> Positions { get; set; } = null!;

    public DbSet<Team> Teams { get; set; } = null!;

    public DbSet<Town> Towns { get; set; } = null!;

    public DbSet<User> Users { get; set; } = null!;

    //Database connection config
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    //FluentAPI and Entities config
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PlayerStatistic>(entity =>
        {
            entity.HasKey(pk => new { pk.GameId, pk.PlayerId });
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity
                .HasOne(t => t.PrimaryKitColor)
                .WithMany(c => c.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Game>(entity =>
        {
            entity
                .HasOne(g => g.HomeTeam)
                .WithMany(h => h.HomeGames)
                .HasForeignKey(f => f.HomeTeamId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(g => g.AwayTeam)
                .WithMany(h => h.AwayGames)
                .HasForeignKey(f => f.AwayTeamId)
                .OnDelete(DeleteBehavior.NoAction);
        });
    }
}
