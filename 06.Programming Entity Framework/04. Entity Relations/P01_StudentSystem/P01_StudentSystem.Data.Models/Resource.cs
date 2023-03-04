using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Common;
using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models;

public class Resource
{
    
    [Key]
    public int ResourceId { get; set; }

    [Required]
    [MaxLength(ValidationConstants.ResourceNameMaxLength)]
    public string Name { get; set; } = null!;

    [Required]
    [Unicode(false)]
    [MaxLength(ValidationConstants.UrlMaxLength)]
    public string Url { get; set; } = null!;

    [Required]
    public ResourceType ResourceType { get; set; }

    [ForeignKey(nameof(Course))]
    public int CourseId { get; set; }
    
    public Course Course { get; set;} = null!;
    
}