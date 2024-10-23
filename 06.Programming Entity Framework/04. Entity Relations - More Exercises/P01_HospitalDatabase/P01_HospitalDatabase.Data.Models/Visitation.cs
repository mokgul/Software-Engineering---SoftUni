namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Visitation
{
    [Key]
    public int VisitationId { get; set; }

    public DateTime Date { get; set; }
    
    [MaxLength(ValidationConstants.MaxLengthComments)]
    public string? Comments { get; set; }

    public Patient Patient { get; set; } = null!;

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }

    public Doctor Doctor { get; set; } = null!;

    [ForeignKey(nameof(Doctor))]
    public int DoctorId { get; set; }
}