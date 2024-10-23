namespace ArtfulAdventures.Data.Configuration;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Models;
using static Common.DataModelsValidationConstants.RolesConstants;

/// <summary>
/// Configuration for seeding Users and Roles to the database.
/// </summary>
public class SeedUsersConfiguration : IEntityTypeConfiguration<ApplicationUser>, IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    private readonly IPasswordHasher<ApplicationUser?> _passwordHasher = new PasswordHasher<ApplicationUser?>();

    //Seed Users
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasData(
            new ApplicationUser
            {
                Id = Guid.Parse("b04c7301-c0c6-4a05-a8ba-8bec078cb212"),
                UserName = "test-user-01",
                NormalizedUserName = "TEST-USER-01",
                Email = "test-user-01@test.art",
                PasswordHash = _passwordHasher.HashPassword(null, "test01"),
                SecurityStamp = "SecurityStampTest01"
            },
            new ApplicationUser
            {
                Id = Guid.Parse("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a"),
                UserName = "test-user-02",
                NormalizedUserName = "TEST-USER-02",
                Email = "test-user-02@test.art",
                PasswordHash = _passwordHasher.HashPassword(null, "test02"),
                SecurityStamp = "SecurityStampTest02"
            },
            new ApplicationUser
            {
                Id = Guid.Parse("cbef4ddc-5788-48ab-9380-aa457c89a554"),
                UserName = "test-user-03",
                NormalizedUserName = "TEST-USER-03",
                Email = "test-user-03@test.art",
                PasswordHash = _passwordHasher.HashPassword(null, "test03"),
                SecurityStamp = "SecurityStampTest03"
            },
            new ApplicationUser
            {
                Id = Guid.Parse("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb"),
                UserName = AdminUserName,
                NormalizedUserName = AdminUserName,
                Email = AdminEmail,
                PasswordHash = _passwordHasher.HashPassword(null, AdminPassword),
                SecurityStamp = "SecurityStampAdmin"
            }
            );
    }

    //Seed Roles to Users
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder
            .HasData(
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse(UserId),
                UserId = Guid.Parse("b04c7301-c0c6-4a05-a8ba-8bec078cb212")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse(UserId),
                UserId = Guid.Parse("c1a9dd0b-8434-421d-8d52-80c8ec3c0e2a")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse(UserId),
                UserId = Guid.Parse("cbef4ddc-5788-48ab-9380-aa457c89a554")
            },
            new IdentityUserRole<Guid>
            {
                RoleId = Guid.Parse(AdminId),
                UserId = Guid.Parse("bd2fe03e-7ab2-4c83-bcb6-10c48aa601cb")
            });
    }
}

