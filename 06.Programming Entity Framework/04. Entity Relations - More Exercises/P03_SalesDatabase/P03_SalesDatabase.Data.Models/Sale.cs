using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P03_SalesDatabase.Data.Models;

public class Sale
{
    [Key]
    public int SaleId { get; set; }

    public DateTime Date { get; set; }

    public Product Product { get; set; } = null!;

    [ForeignKey(nameof(Product))]
    public int ProductId { get; set; }

    public Customer Customer { get; set; } = null!;

    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    public Store Store { get; set; } = null!;

    [ForeignKey(nameof(Store))]
    public int StoreId { get; set; }
}