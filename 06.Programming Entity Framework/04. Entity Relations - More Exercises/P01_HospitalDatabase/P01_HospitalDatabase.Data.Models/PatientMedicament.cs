namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class PatientMedicament
{
    public Patient Patient { get; set; } = null!;

    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }

    public Medicament Medicament { get; set; } = null!;

    [ForeignKey(nameof(Medicament))]
    public int MedicamentId { get; set; }
}