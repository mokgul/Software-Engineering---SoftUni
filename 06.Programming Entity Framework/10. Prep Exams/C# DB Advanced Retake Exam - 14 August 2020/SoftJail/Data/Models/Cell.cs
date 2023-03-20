namespace SoftJail.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Cell
{
    public Cell()
    {
        this.Prisoners = new HashSet<Prisoner>();
    }

    [Key]
    public int Id { get; set; }

    public int CellNumber { get; set; }

    public bool HasWindow { get; set; }

    public virtual Department Department { get; set; }

    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }

    public virtual ICollection<Prisoner> Prisoners { get; set; }

}