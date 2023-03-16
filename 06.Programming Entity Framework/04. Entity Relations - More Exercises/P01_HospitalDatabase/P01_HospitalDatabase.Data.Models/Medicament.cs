namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

public class Medicament
{
    public Medicament()
    {
        Prescriptions = new HashSet<PatientMedicament>();
    }

    [Key]
    public int MedicamentId { get; set; }

    [MaxLength(ValidationConstants.MaxLengthMedicamentName)]
    public string Name { get; set; } = null!;

    public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
}