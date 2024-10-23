namespace ArtfulAdventures.Data.Models;

using ArtfulAdventures.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// Represents a skill that a <see cref="ApplicationUser"/> can have.
/// </summary>
public class Skill
{
    public Skill()
    {
        ApplicationUsersSkills = new HashSet<ApplicationUserSkill>();
    }
    public Skill(SkillType type) : this()
    {
        this.Type = type.ToString();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Type { get; set; } = null!;

    public ICollection<ApplicationUserSkill> ApplicationUsersSkills { get; set; }
}

