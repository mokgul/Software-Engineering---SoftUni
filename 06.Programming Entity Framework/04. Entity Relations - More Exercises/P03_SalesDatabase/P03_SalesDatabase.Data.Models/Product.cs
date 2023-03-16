namespace P03_SalesDatabase.Data.Models;

using System.ComponentModel.DataAnnotations;

using Common;

    public class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        [Key]
        public int ProductId { get; set; }

        [MaxLength(ValidationConstants.MaxLengthProductName)]
        public string Name { get; set; } = null!;

        public double Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Sale> Sales { get; set; } = null!;

    }
