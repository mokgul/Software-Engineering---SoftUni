namespace ArtfulAdventures.Data.EnumSeeders;

using Models;
using Models.Enums;

/// <summary>
/// Generate a Collection of HashTags for the Enum Configuration
/// </summary>
public class HashTagsSeed
{
    public readonly ICollection<HashTag> HashTags;
    
    public HashTagsSeed()
    {
        HashTags = new List<HashTag>();
        HashTags = GenerateHashTags();
    }

    //Generate HashTags
    private ICollection<HashTag> GenerateHashTags()
    {
        var id = 0;
        foreach (var type in Enum.GetValues(typeof(HashTagType)))
        {
            id++;
            HashTags.Add(new HashTag((HashTagType)type) {Id = id}); 
        }
        return HashTags;
    }
}

