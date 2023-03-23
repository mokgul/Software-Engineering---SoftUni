namespace VaporStore.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Developer
{
    public Developer()
    {
        this.Games = new HashSet<Game>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public virtual ICollection<Game> Games { get; set; }

}