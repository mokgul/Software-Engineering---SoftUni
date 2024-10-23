namespace TeisterMask.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Employee
{
    public Employee()
    {
        this.EmployeesTasks = new HashSet<EmployeeTask>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    public string Username { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required]
    public string Phone { get; set; } = null!;

    public virtual ICollection<EmployeeTask> EmployeesTasks { get; set; }

}