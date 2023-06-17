using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        [Required]
        [ForeignKey(nameof(Collector))]
        public string CollectorId { get; set; }
        public IdentityUser Collector { get; set; }

        [Required]
        [ForeignKey(nameof(Book))]
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
