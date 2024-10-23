using SoftJail.Data.Models;

namespace SoftJail.Data
{
    using Microsoft.EntityFrameworkCore;

    public class SoftJailDbContext : DbContext
    {
        public SoftJailDbContext()
        {
        }

        public SoftJailDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Cell> Cells { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<Officer> Officers { get; set; }

        public DbSet<OfficerPrisoner> OfficersPrisoners { get; set; }

        public DbSet<Prisoner> Prisoners { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<OfficerPrisoner>(entity =>
            {
                entity.HasKey(pk => new { pk.OfficerId, pk.PrisonerId });

                //entity
                //    .HasOne(p => p.Prisoner)
                //    .WithMany(o => o.PrisonerOfficers)
                //    .HasForeignKey(p => p.PrisonerId)
                //    .OnDelete(DeleteBehavior.Restrict);
                //entity
                //    .HasOne(p => p.Officer)
                //    .WithMany(o => o.OfficerPrisoners)
                //    .HasForeignKey(p => p.OfficerId)
                //    .OnDelete(DeleteBehavior.Restrict);

            });

        }
    }
}