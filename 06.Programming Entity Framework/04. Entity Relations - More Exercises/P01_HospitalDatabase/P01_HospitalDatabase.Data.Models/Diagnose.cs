namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Common;

public class Diagnose
{
    [Key]
    public int DiagnoseId { get; set; }

    [MaxLength(ValidationConstants.MaxLengthDiagnoseName)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstants.MaxLengthComments)]
    public string? Comments { get; set; }

    public Patient Patient { get; set; } = null!;

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
}