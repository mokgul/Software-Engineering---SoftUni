namespace P01_HospitalDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using Common;

public class Patient
    {
        public Patient()
        {
            Visitations = new HashSet<Visitation>();
            Diagnoses = new HashSet<Diagnose>();
            Prescriptions = new HashSet<PatientMedicament>();
        }

        [Key]
        public int PatientId { get; set; }

        [MaxLength(ValidationConstants.MaxLengthFirstName)]
        public string FirstName { get; set; } = null!;

        [MaxLength(ValidationConstants.MaxLengthLastName)]
        public string LastName { get; set; } = null!;

        [MaxLength(ValidationConstants.MaxLengthAddress)]
        public string? Address { get; set; }

        [MaxLength(ValidationConstants.MaxLengthEmail)]
        [Unicode(false)]
        public string? Email { get; set; }

        public bool HasInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }

        public virtual ICollection<Diagnose> Diagnoses { get; set; }

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; }
    }
