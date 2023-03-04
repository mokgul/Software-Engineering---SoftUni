using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models;

public class StudentCourse
{
    
    public Student Student { get; set; } = null!;

    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }

    
    public Course Course { get; set; } = null!;

    [ForeignKey(nameof(Course))] 
    public int CourseId { get; set; }

}