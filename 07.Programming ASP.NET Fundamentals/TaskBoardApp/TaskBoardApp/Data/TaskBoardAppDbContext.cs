namespace TaskBoardApp.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using TaskBoardApp.Data.Models;

using static TaskBoardApp.Data.Seeding;

public class TaskBoardAppDbContext : IdentityDbContext
{
    public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
        : base(options){ }   

    public DbSet<Board> Boards { get; set; } = null!;

    public DbSet<Models.Task> Tasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .Entity<Models.Task>()
            .HasOne(b => b.Board)
            .WithMany(t => t.Tasks)
            .HasForeignKey(t => t.BoardId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Entity<IdentityUser>()
            .HasData(TestUser);

        builder
            .Entity<Board>()
            .HasData(new Boards().BoardsList);

        builder
            .Entity<Models.Task>()
            .HasData(new Tasks().TasksList);

        base.OnModelCreating(builder);
    }
}
