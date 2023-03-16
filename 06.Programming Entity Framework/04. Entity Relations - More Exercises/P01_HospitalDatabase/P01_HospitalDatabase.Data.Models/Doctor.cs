using System.ComponentModel.DataAnnotations;
using P01_HospitalDatabase.Data.Common;

namespace P01_HospitalDatabase.Data.Models;

public class Doctor
{
    public Doctor()
    {
        Visitations = new HashSet<Visitation>();
    }
    [Key]
    public int DoctorId { get; set; }

    [MaxLength(ValidationConstants.MaxLengthDoctorName)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstants.MaxLengthSpecialty)]
    public string Specialty { get; set; } = null!;

    public virtual ICollection<Visitation> Visitations { get; set; } = null!;
}