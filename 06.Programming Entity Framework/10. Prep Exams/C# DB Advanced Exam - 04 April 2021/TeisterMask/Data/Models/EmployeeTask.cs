namespace TeisterMask.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class EmployeeTask
{
    public Employee Employee { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Employee))]
    public int EmployeeId { get; set; }

    public Task Task { get; set; } = null!;

    [Required]
    [ForeignKey(nameof(Task))]
    public int TaskId { get; set; }

}