namespace ArtfulAdventures.Data.EnumSeeders;

using Models;
using Models.Enums;

/// <summary>
/// Generate Skills for the EnumConfiguration
/// </summary>
public class SkillsSeed
{
    public readonly ICollection<Skill> Skills;
    public SkillsSeed()
    {
        Skills = new List<Skill>();
        Skills = GenerateHashSkills();
    }

    //Generate Skills
    private ICollection<Skill> GenerateHashSkills()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(SkillType)))
        {
            id++;
            Skills.Add(new Skill((SkillType)type) { Id = id });
        }
        return Skills;
    }
}

