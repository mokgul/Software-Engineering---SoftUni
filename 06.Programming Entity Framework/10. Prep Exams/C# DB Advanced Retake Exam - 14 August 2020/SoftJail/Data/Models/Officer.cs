namespace SoftJail.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Enums;

public class Officer
{
    public Officer()
    {
        this.OfficerPrisoners = new HashSet<OfficerPrisoner>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string FullName { get; set; }

    public decimal Salary { get; set; }

    public Position Position { get; set; }

    public Weapon Weapon { get; set; }

    public virtual Department Department { get; set; }

    [ForeignKey(nameof(Department))]
    public int DepartmentId { get; set; }

    public virtual ICollection<OfficerPrisoner> OfficerPrisoners { get; set; }

}