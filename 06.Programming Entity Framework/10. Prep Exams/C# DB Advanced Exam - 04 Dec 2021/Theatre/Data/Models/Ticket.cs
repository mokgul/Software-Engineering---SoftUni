using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Theatre.Data.Models;

public class Ticket
{
   [Key]
   public int Id { get; set; }

   [Required]
   public decimal Price { get; set; }

   [Required]
   public sbyte RowNumber { get; set; }

   public Play Play { get; set; }

   [Required]
   [ForeignKey(nameof(Play))]
   public int PlayId { get; set; }

   public Theatre Theatre { get; set; }

   [Required]
   [ForeignKey(nameof(Theatre))]
   public int TheatreId { get; set; }

}