namespace P03_SalesDatabase.Data;

using Microsoft.EntityFrameworkCore;

using Models;
using Common;

public class SalesContext : DbContext
{
    public SalesContext()
    {
       
    }

    public SalesContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(DbConfig.ConnectionString);
        }
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //TODO: Relations with FluentAPI => No relations needed at the moment
    }
}

