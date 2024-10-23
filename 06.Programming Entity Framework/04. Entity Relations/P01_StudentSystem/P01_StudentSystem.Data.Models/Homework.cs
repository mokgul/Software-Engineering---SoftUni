using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models;

public class Homework
{
    public Homework()
    {
    }

    [Key]
    public int HomeworkId { get; set; }

    [Required] 
    [Unicode(false)]
    public string Content { get; set; } = null!;

    [Required]
    public ContentType ContentType { get; set; }

    public DateTime SubmissionTime  { get; set; }

    public Student Student { get; set; } = null!;

    [ForeignKey(nameof(Student))]
    public int StudentId { get; set; }

    
    public Course Course { get; set; } = null!;

    [ForeignKey(nameof(Course))] 
    public int CourseId { get; set; }

}