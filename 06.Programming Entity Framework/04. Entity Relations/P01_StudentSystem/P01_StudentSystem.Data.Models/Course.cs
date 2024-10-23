using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P01_StudentSystem.Data.Common;

namespace P01_StudentSystem.Data.Models;

public class Course
{
    public Course()
    {
        StudentsCourses = new HashSet<StudentCourse>();
        Resources = new HashSet<Resource>();
        Homeworks = new HashSet<Homework>();
    }

    [Key]
    public int CourseId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.CourseNameMaxLength)]
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal Price { get; set; }

    
    public virtual ICollection<Resource> Resources { get; set; }

    public virtual  ICollection<Homework> Homeworks { get; set; }

    public virtual ICollection<StudentCourse> StudentsCourses { get; set; }
}