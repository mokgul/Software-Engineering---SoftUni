namespace VaporStore.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Tag
{
    public Tag()
    {
        this.GameTags = new HashSet<GameTag>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<GameTag> GameTags { get; set; }

}