namespace P03_SalesDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using Common;

public class Customer
{
    public Customer()
    {
        Sales = new HashSet<Sale>();
    }
    [Key]
    public int CustomerId { get; set; }

    [MaxLength(ValidationConstants.MaxLengthCustomerName)]
    public string Name { get; set; } = null!;

    [MaxLength(ValidationConstants.MaxLengthEmailName)]
    [Unicode(false)]
    public string? Email { get; set; }

    public string CreditCardNumber { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = null!;

}