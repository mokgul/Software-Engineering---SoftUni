namespace TeisterMask.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Project
{
    public Project()
    {
        this.Tasks = new HashSet<Task>();
    }
    
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;
        
    [Required]
    public DateTime OpenDate { get; set; } 

    public DateTime? DueDate { get; set; }

    public virtual ICollection<Task> Tasks { get; set; }

}